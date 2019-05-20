using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using SiegeApi.Exceptions;
using SiegeApi.Models;
using SiegeApi.Utility;

namespace SiegeApi.Tests.Tests
{
    [Order(2), SingleThreaded, NonParallelizable]
    public class StatsTests
    {
        [SetUp]
        public void Setup()
        {
            Monitor.Enter(Singletons.MonitorObject);
        }

        [TearDown]
        public void TearDown()
        {
            Monitor.Exit(Singletons.MonitorObject);
        }
        
        [Test]
        public async Task QueryStats()
        {
            try
            {
                UserStats statsFromUserProfile = await Singletons.ApiClient.GetStatsAsync(Singletons.UserProfile);
                Assert.NotNull(statsFromUserProfile, "Result of GetStatsAsync is null.");

                Dictionary<Guid, UserStats> statsFromUserId = await Singletons.ApiClient.GetStatsAsync(Singletons.UserProfile.Platform, Singletons.UserProfile.UserId);
                Assert.IsTrue(statsFromUserId.All(x => x.Key == Singletons.UserProfile.UserId), "Returned stats does not have matching user ids.");
            }
            catch (NotLoggedInException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void MergeStats()
        {
            #region Stats creation and comparison methods
            
            QueueStats CreateQueueStats(int num) => new QueueStats
            {
                Deaths = num,
                Kills = num,
                TimePlayed = num,
                MatchesLost = num,
                MatchesWon = num
            };

            GameModeStats CreateGameModeStats(int num) => new GameModeStats
            {
                MatchesLost = num,
                MatchesWon = num,
                TimePlayed = num,
                BestScore = num
            };

            UserStats CreateStats(int num) => new UserStats
            {
                Operators = new List<OperatorStats>
                {
                    new OperatorStats
                    {
                        Deaths = num,
                        Kills = num,
                        GadgetStats = new Dictionary<string, int>
                        {
                            {"test", num}
                        },
                        RoundsLost = num,
                        RoundsWon = num,
                        TimePlayed = num
                    }
                },
                CasualStats = CreateQueueStats(num),
                RankedStats = CreateQueueStats(num),
                GameModes = new GameModesStats
                {
                    Bomb = CreateGameModeStats(num),
                    Hostage = CreateGameModeStats(num),
                    SecureArea = CreateGameModeStats(num)
                },
                PvpStats = new PvpStats
                {
                    Deaths = num,
                    Headshots = num,
                    Kills = num,
                    BulletsFired = num,
                    BulletsHit = num,
                    MatchesLost = num,
                    MatchesWon = num,
                    TimePlayed = num,
                    Dbno = num,
                    Revives = num,
                    Suicides = num,
                    BlindKills = num,
                    DbnoAssists = num,
                    DeniedRevives = num,
                    GadgetsDestroyed = num,
                    HostagesDefended = num,
                    HostagesRescued = num,
                    KillAssists = num,
                    MeleeKills = num,
                    PenetrationKills = num,
                    RappelBreaches = num
                },
                WeaponStats = new Dictionary<WeaponType, WeaponStats>
                {
                    {
                        WeaponType.Assault, new WeaponStats
                        {
                            Kills = num,
                            Headshots = num,
                            BulletsFired = num,
                            BulletsHit = num
                        }
                    }
                }
            };

            bool CompareQueueStats(QueueStats a, QueueStats b)
            {
                return a.Deaths == b.Deaths &&
                       a.Kills == b.Kills &&
                       a.MatchesLost == b.MatchesLost &&
                       a.MatchesWon == b.MatchesWon &&
                       a.TimePlayed == b.TimePlayed;
            }

            bool CompareGameModeStats(GameModeStats a, GameModeStats b)
            {
                return a.BestScore == b.BestScore &&
                       a.MatchesLost == b.MatchesLost &&
                       a.MatchesWon == b.MatchesWon &&
                       a.TimePlayed == b.TimePlayed;
            }

            bool ComparePvpStats(PvpStats a, PvpStats b)
            {
                return a.Dbno == b.Dbno &&
                       a.Deaths == b.Deaths &&
                       a.Kills == b.Kills &&
                       a.Headshots == b.Headshots &&
                       a.Revives == b.Revives &&
                       a.Suicides == b.Suicides &&
                       a.BlindKills == b.BlindKills &&
                       a.BulletsFired == b.BulletsFired &&
                       a.BulletsHit == b.BulletsHit &&
                       a.DbnoAssists == b.DbnoAssists &&
                       a.DeniedRevives == b.DeniedRevives &&
                       a.GadgetsDestroyed == b.GadgetsDestroyed &&
                       a.HostagesDefended == b.HostagesDefended &&
                       a.HostagesRescued == b.HostagesRescued &&
                       a.KillAssists == b.KillAssists &&
                       a.MatchesLost == b.MatchesLost &&
                       a.MatchesWon == b.MatchesWon &&
                       a.MeleeKills == b.MeleeKills &&
                       a.PenetrationKills == b.PenetrationKills &&
                       a.RappelBreaches == b.RappelBreaches &&
                       a.TimePlayed == b.TimePlayed;
            }

            bool CompareWeaponStats(WeaponStats a, WeaponStats b)
            {
                return a.Headshots == b.Headshots &&
                       a.Kills == b.Kills &&
                       a.BulletsFired == b.BulletsFired &&
                       a.BulletsHit == b.BulletsHit;
            }

            bool CompareWeaponStatsDictionaries(Dictionary<WeaponType, WeaponStats> a, Dictionary<WeaponType, WeaponStats> b)
            {
                return a.All(kv => CompareWeaponStats(kv.Value, b[kv.Key]));
            }

            bool CompareStats(UserStats a, UserStats b)
            {
                if (!a.Operators.All(aOpStats =>
                {
                    var bOpStats = b.Operators.First(op => op.Operator == aOpStats.Operator);

                    return aOpStats.Deaths == bOpStats.Deaths &&
                           aOpStats.Kills == bOpStats.Kills &&
                           aOpStats.RoundsLost == bOpStats.RoundsLost &&
                           aOpStats.RoundsWon == bOpStats.RoundsWon &&
                           aOpStats.TimePlayed == bOpStats.TimePlayed;
                }))
                {
                    return false;
                }

                if (!CompareQueueStats(a.CasualStats, b.CasualStats) || !CompareQueueStats(a.RankedStats, b.RankedStats))
                    return false;

                if (!CompareGameModeStats(a.GameModes.Bomb, b.GameModes.Bomb) ||
                    !CompareGameModeStats(a.GameModes.Hostage, b.GameModes.Hostage) ||
                    !CompareGameModeStats(a.GameModes.SecureArea, b.GameModes.SecureArea))
                    return false;

                if (!ComparePvpStats(a.PvpStats, b.PvpStats))
                    return false;

                if (!CompareWeaponStatsDictionaries(a.WeaponStats, b.WeaponStats))
                    return false;

                return true;
            }
            
            #endregion

            var aStats = CreateStats(1);
            var bStats = CreateStats(1);
            var merged = aStats.MergeStats(bStats);
            var expected = CreateStats(2);
            Assert.IsTrue(CompareStats(merged, expected), "Stats did not successfully merge");

            var delta = aStats.CalculateDelta(bStats);
            var expectedDelta = CreateStats(0);
            Assert.IsTrue(CompareStats(delta, expectedDelta), "Incorrect delta values");
        }
    }
}