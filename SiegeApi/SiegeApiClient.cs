using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using SiegeApi.Data;
using SiegeApi.Exceptions;
using SiegeApi.Models;
using SiegeApi.Requests;
using SiegeApi.Requests.ResponseModels;

namespace SiegeApi
{
    public class SiegeApiClient : IDisposable
    {
        public AuthResponse CurrentLogin { get; private set; }
        public bool LoggedIn => CurrentLogin != null;

        internal RestClient RestClient { get; private set; }
        
        private CancellationTokenSource renewCancellation;
        private Task renewTask;
        
        public SiegeApiClient()
        {
            RestClient = new RestClient();
            RestClient
                .AddDefaultHeader("Ubi-AppId", "39baebad-39e5-4552-8c25-2c9b919064e2")
                .AddDefaultHeader("Content-Type", "application/json; charset=UTF-8");

            var jsonHandler = CustomJsonSerializer.Default;
            RestClient.AddHandler("application/json", () => jsonHandler);
            RestClient.AddHandler("application/json; charset=utf-8", () => jsonHandler);
        }

        public void Dispose()
        {
            renewCancellation?.Cancel();
            CurrentLogin = null;
        }

        public async Task LoginAsync(string email, string password)
        {
            try
            {
                RestClient.Authenticator = new HttpBasicAuthenticator(email, password);
                CurrentLogin = await AuthRequests.SendAuthRequestAsync(RestClient);

                // Schedule renewing session before it expires
                var renewTime = CurrentLogin.Expiration.AddSeconds(-(10 * 60)); // Renew auth 10 minutes before it expires
                var renewDelay = renewTime - DateTime.UtcNow;

                if (renewDelay > TimeSpan.Zero)
                {
                    Console.WriteLine($"Renewing token at {renewTime}");

                    renewCancellation = new CancellationTokenSource();
                    renewTask = RenewLoginAsync(renewDelay, email, password, renewCancellation.Token);
                }
            }
            finally
            {
                RestClient.Authenticator = null;
            }
        }

        private async Task RenewLoginAsync(TimeSpan delay, string email, string password, CancellationToken cancellationToken)
        {
            await Task.Delay(delay, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            await LoginAsync(email, password);
        }
        
        #region Profile

        public async Task<UserProfile> FindProfileAsync(string username, Platform platform)
        {
            ProfileResponse response = await ProfileRequests.FindProfileAsync(this, username, platform);
            return response.Profiles.FirstOrDefault();
        }

        public async Task<UserProfile[]> FindProfilesAsync(Guid userId)
        {
            ProfileResponse response = await ProfileRequests.FindProfilesAsync(this, userId);
            return response.Profiles;
        }
        
        #endregion
        
        #region Stats

        public async Task<UserStats> GetStatsAsync(UserProfile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            return (await GetStatsAsync(profile.Platform, profile.UserId)).FirstOrDefault(x => x.Key == profile.ProfileId).Value;
        }

        public async Task<Dictionary<Guid, UserStats>> GetStatsAsync(Platform platform, params Guid[] userIds)
        {
            var response = await StatsRequests.GetStats(this, platform, userIds);
            var result = new Dictionary<Guid, UserStats>();
            
            foreach (var kv in response.Results)
            {
                var userId = Guid.Parse(kv.Key);
                var allStats = kv.Value;
                
                var allOperatorStats = new List<OperatorStats>();
                foreach (var op in Operators.Data)
                {
                    var gadgetStats = new Dictionary<string, int>();

                    foreach (var gadgetStatId in op.Gadgets)
                    {
                        gadgetStats.Add(gadgetStatId, GetStatValue(allStats, $"{gadgetStatId}:{op.FullIndex}:infinite"));
                    }

                    var operatorStats = new OperatorStats
                    {
                        Operator = op,
                        TimePlayed = GetStatValue(allStats, $"operatorpvp_timeplayed:{op.FullIndex}:infinite"),
                        Kills = GetStatValue(allStats, $"operatorpvp_kills:{op.FullIndex}:infinite"),
                        Deaths = GetStatValue(allStats, $"operatorpvp_death:{op.FullIndex}:infinite"),
                        RoundsWon = GetStatValue(allStats, $"operatorpvp_roundwon:{op.FullIndex}:infinite"),
                        RoundsLost = GetStatValue(allStats, $"operatorpvp_roundlost:{op.FullIndex}:infinite"),
                        GadgetStats = gadgetStats
                    };

                    allOperatorStats.Add(operatorStats);
                }

                result.Add(userId, new UserStats
                {
                    Operators = allOperatorStats,
                    CasualStats = GetQueueStats(allStats, "casual"),
                    RankedStats = GetQueueStats(allStats, "ranked"),
                    PvpStats = new PvpStats
                    {
                        Deaths = GetStatValue(allStats, "generalpvp_death:infinite"),
                        Kills = GetStatValue(allStats, "generalpvp_kills:infinite"),
                        MatchesLost = GetStatValue(allStats, "generalpvp_matchlost:infinite"),
                        MatchesWon = GetStatValue(allStats, "generalpvp_matchwon:infinite"),
                        TimePlayed = GetStatValue(allStats, "generalpvp_timeplayed:infinite"),
                        Dbno = GetStatValue(allStats, "generalpvp_dbno:infinite"),
                        Headshots = GetStatValue(allStats, "generalpvp_headshot:infinite"),
                        Revives = GetStatValue(allStats, "generalpvp_revive:infinite"),
                        Suicides = GetStatValue(allStats, "generalpvp_suicide:infinite"),
                        BlindKills = GetStatValue(allStats, "generalpvp_blindkills:infinite"),
                        BulletsFired = GetStatValue(allStats, "generalpvp_bulletfired:infinite"),
                        BulletsHit = GetStatValue(allStats, "generalpvp_bullethit:infinite"),
                        DeniedRevives = GetStatValue(allStats, "generalpvp_revivedenied:infinite"),
                        DbnoAssists = GetStatValue(allStats, "generalpvp_dnboassists:infinite"),
                        GadgetsDestroyed = GetStatValue(allStats, "generalpvp_gadgetdestroy:infinite"),
                        HostagesDefended = GetStatValue(allStats, "generalpvp_hostagedefense:infinite"),
                        HostagesRescued = GetStatValue(allStats, "generalpvp_hostagerescue:infinite"),
                        KillAssists = GetStatValue(allStats, "generalpvp_killassists:infinite"),
                        MeleeKills = GetStatValue(allStats, "generalpvp_meleekills:infinite"),
                        PenetrationKills = GetStatValue(allStats, "generalpvp_penetrationkills:infinite"),
                        RappelBreaches = GetStatValue(allStats, "generalpvp_rappelbreach:infinite")
                    },
                    GameModes = new GameModesStats
                    {
                        Bomb = GetGameModeStats(allStats, "plantbomb"),
                        Hostage = GetGameModeStats(allStats, "rescuehostage"),
                        SecureArea = GetGameModeStats(allStats, "securearea")
                    },
                    WeaponStats = new Dictionary<WeaponType, WeaponStats>
                    {
                        {WeaponType.Assault, GetWeaponStats(allStats, "1")},
                        {WeaponType.Smg, GetWeaponStats(allStats, "2")},
                        {WeaponType.Lmg, GetWeaponStats(allStats, "3")},
                        {WeaponType.Sniper, GetWeaponStats(allStats, "4")},
                        {WeaponType.Pistol, GetWeaponStats(allStats, "5")},
                        {WeaponType.Shotgun, GetWeaponStats(allStats, "6")},
                        {WeaponType.MachinePistol, GetWeaponStats(allStats, "7")},
                        {WeaponType.Shield, GetWeaponStats(allStats, "8")},
                        {WeaponType.Launcher, GetWeaponStats(allStats, "9")},
                        {WeaponType.B, GetWeaponStats(allStats, "B")}
                    }
                });
            }

            return result;
        }

        private WeaponStats GetWeaponStats(Dictionary<string, int> allStats, string weaponIndex)
        {
            return new WeaponStats
            {
                Headshots = GetStatValue(allStats, $"weapontypepvp_headshot:{weaponIndex}:infinite"),
                Kills = GetStatValue(allStats, $"weapontypepvp_kills:{weaponIndex}:infinite"),
                BulletsFired = GetStatValue(allStats, $"weapontypepvp_bulletfired:{weaponIndex}:infinite"),
                BulletsHit = GetStatValue(allStats, $"weapontypepvp_bullethit:{weaponIndex}:infinite")
            };
        }

        private GameModeStats GetGameModeStats(Dictionary<string, int> allStats, string gameMode)
        {
            return new GameModeStats
            {
                MatchesLost = GetStatValue(allStats, $"{gameMode}pvp_matchlost:infinite"),
                MatchesWon = GetStatValue(allStats, $"{gameMode}pvp_matchwon:infinite"),
                TimePlayed = GetStatValue(allStats, $"{gameMode}pvp_timeplayed:infinite"),
                BestScore = GetStatValue(allStats, $"{gameMode}pvp_bestscore:infinite")
            };
        }

        private QueueStats GetQueueStats(Dictionary<string, int> allStats, string queueName)
        {
            return new QueueStats
            {
                Kills = GetStatValue(allStats, $"{queueName}pvp_kills:infinite"),
                Deaths = GetStatValue(allStats, $"{queueName}pvp_death:infinite"),
                MatchesWon = GetStatValue(allStats, $"{queueName}pvp_matchwon:infinite"),
                MatchesLost = GetStatValue(allStats, $"{queueName}pvp_matchlost:infinite"),
                TimePlayed = GetStatValue(allStats, $"{queueName}pvp_timeplayed:infinite")
            };
        }

        private int GetStatValue(Dictionary<string, int> stats, string statName, int defaultValue = 0)
        {
            return stats.TryGetValue(statName, out int result) ? result : defaultValue;
        }
        
        #endregion

        #region Rank
        
        public async Task<Dictionary<Guid, RankStats>> GetRanksAsync(Platform platform, Region region, Season season, params Guid[] userIds)
        {
            RankResponse response = await RankRequests.GetRank(this, platform, region, season, userIds);
            return response.Players.ToDictionary(kv => Guid.Parse(kv.Key), kv => kv.Value);
        }

        public async Task<Dictionary<Guid, Dictionary<Season, RankStats>>> GetRanksAsync(Platform platform, Region region, params Guid[] userIds)
        {
            var tasks = Seasons.Data.Where(season => season.Id > 5).Select(season => GetRanksAsync(platform, region, season, userIds));
            Dictionary<Guid, RankStats>[] results = await Task.WhenAll(tasks);
            var result = new Dictionary<Guid, Dictionary<Season, RankStats>>();
            List<KeyValuePair<Guid, RankStats>> flattenedStats = results.SelectMany(dict => dict).ToList();

            foreach (Dictionary<Guid, RankStats> playerDicts in results)
            {
                Guid userId = playerDicts.First().Key;
                var playerDict = GetValueOrDefault(result, userId, () => new Dictionary<Season, RankStats>());

                if (playerDict.Count > 0)
                    continue;

                foreach (RankStats rankStats in flattenedStats.Where(kv2 => userId == kv2.Key).Select(kv2 => kv2.Value))
                {
                    playerDict.Add(rankStats.Season, rankStats);
                }
            }
            
            return result;
        }
        
        public async Task<Dictionary<Guid, Dictionary<Region, RankStats>>> GetRanksAsync(Platform platform, Season season, params Guid[] userIds)
        {
            var regions = new[] {Region.Europe, Region.America, Region.Asia};
            var tasks = regions.Select(region => GetRanksAsync(platform, region, season, userIds));
            Dictionary<Guid, RankStats>[] results = await Task.WhenAll(tasks);
            var result = new Dictionary<Guid, Dictionary<Region, RankStats>>();
            List<KeyValuePair<Guid, RankStats>> flattenedStats = results.SelectMany(dict => dict).ToList();

            foreach (Dictionary<Guid, RankStats> playerDicts in results)
            {
                Guid userId = playerDicts.First().Key;
                var playerDict = GetValueOrDefault(result, userId, () => new Dictionary<Region, RankStats>());

                if (playerDict.Count > 0)
                    continue;

                foreach (var rankStats in flattenedStats.Where(kv => userId == kv.Key).Select(kv => kv.Value))
                {
                    playerDict.Add(rankStats.Region, rankStats);
                }
            }

            return result;
        }

        public async Task<Dictionary<Guid, Dictionary<Season, Dictionary<Region, RankStats>>>> GetRanksAsync(Platform platform, params Guid[] userIds)
        {
            var regions = new[] {Region.Europe, Region.America, Region.Asia};
            var tasks = Seasons.Data.Where(season => season.Id > 5).SelectMany(season => regions.Select(region => GetRanksAsync(platform, region, season, userIds)));
            Dictionary<Guid, RankStats>[] results = await Task.WhenAll(tasks);
            var result = new Dictionary<Guid, Dictionary<Season, Dictionary<Region, RankStats>>>();
            List<KeyValuePair<Guid, RankStats>> flattenedStats = results.SelectMany(dict => dict).ToList();

            foreach (Dictionary<Guid, RankStats> playerDicts in results)
            {
                Guid userId = playerDicts.First().Key;
                var playerDict = GetValueOrDefault(result, userId, () => new Dictionary<Season, Dictionary<Region, RankStats>>());

                if (playerDict.Count > 0)
                    continue;

                foreach (RankStats rankStats in flattenedStats.Where(kv2 => userId == kv2.Key).Select(kv2 => kv2.Value))
                {
                    var seasonStats = GetValueOrDefault(playerDict, rankStats.Season, () => new Dictionary<Region, RankStats>());
                    seasonStats.Add(rankStats.Region, rankStats);
                }
            }
            
            return result;
        }

        private TValue GetValueOrDefault<TKey, TValue>(Dictionary<TKey, TValue> source, TKey key, Func<TValue> defaultValueInstantiator)
        {
            if (source.TryGetValue(key, out var result))
                return result;
            
            var value = defaultValueInstantiator();
            source.Add(key, value);
            return value;
        }

        #endregion
        
        private string GetAuthorizationToken()
        {
            if (!LoggedIn)
                throw new NotLoggedInException("Can't retrieve auth token because the client is not logged in.");

            return CurrentLogin.Ticket;
        }

        internal string GetAuthorizationHeader()
        {
            return $"Ubi_v1 t={GetAuthorizationToken()}";
        }
    }
}