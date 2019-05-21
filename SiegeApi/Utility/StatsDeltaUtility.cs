using System.Collections.Generic;
using System.Linq;
using SiegeApi.Models;

namespace SiegeApi.Utility
{
    public static class StatsDeltaUtility
    {
        /// <summary>
        /// Returns the delta stats between a and b.
        /// </summary>
        public static UserStats CalculateDelta(this UserStats a, UserStats b)
        {
            return new UserStats
            {
                Operators = CalculateOperatorsStatsDelta(a.Operators, b.Operators),
                CasualStats = CalculateQueueStatsDelta(a.CasualStats, b.CasualStats),
                RankedStats = CalculateQueueStatsDelta(a.RankedStats, b.RankedStats),
                GameModes = new GameModesStats
                {
                    Bomb = CalculateGameModeStatsDelta(a.GameModes.Bomb, b.GameModes.Bomb),
                    Hostage = CalculateGameModeStatsDelta(a.GameModes.Hostage, b.GameModes.Hostage),
                    SecureArea = CalculateGameModeStatsDelta(a.GameModes.SecureArea, b.GameModes.SecureArea)
                },
                PvpStats = CalculatePvpStatsDelta(a.PvpStats, b.PvpStats),
                WeaponStats = CalculateWeaponStatsDelta(a.WeaponStats, b.WeaponStats)
            };
        }

        private static List<OperatorStats> CalculateOperatorsStatsDelta(ICollection<OperatorStats> a, ICollection<OperatorStats> b)
        {
            return b.Select(bOp =>
            {
                var aOp = a.FirstOrDefault(x => x.Operator == bOp.Operator) ?? new OperatorStats
                {
                    Operator = bOp.Operator,
                    GadgetStats = new Dictionary<string, int>()
                };

                return new OperatorStats
                {
                    Operator = bOp.Operator,
                    Deaths = bOp.Deaths - aOp.Deaths,
                    Kills = bOp.Kills - aOp.Kills,
                    RoundsLost = bOp.RoundsLost - aOp.RoundsLost,
                    RoundsWon = bOp.RoundsWon - aOp.RoundsWon,
                    TimePlayed = bOp.TimePlayed - aOp.TimePlayed,
                    GadgetStats = bOp.GadgetStats.ToDictionary(kv => kv.Key, kv => kv.Value - (aOp.GadgetStats.ContainsKey(kv.Key) ? aOp.GadgetStats[kv.Key] : 0))
                };
            }).ToList();
        }

        private static QueueStats CalculateQueueStatsDelta(QueueStats a, QueueStats b)
        {
            return new QueueStats
            {
                Deaths = b.Deaths - a.Deaths,
                Kills = b.Kills - a.Kills,
                TimePlayed = b.TimePlayed - a.TimePlayed,
                MatchesLost = b.MatchesLost - a.MatchesLost,
                MatchesWon = b.MatchesWon - a.MatchesWon
            };
        }

        private static GameModeStats CalculateGameModeStatsDelta(GameModeStats a, GameModeStats b)
        {
            return new GameModeStats
            {
                MatchesLost = b.MatchesLost - a.MatchesLost,
                MatchesWon = b.MatchesWon - a.MatchesWon,
                TimePlayed = b.TimePlayed - a.TimePlayed,
                BestScore = b.BestScore - a.BestScore
            };
        }

        private static PvpStats CalculatePvpStatsDelta(PvpStats a, PvpStats b)
        {
            return new PvpStats
            {
                Deaths = b.Deaths - a.Deaths,
                Kills = b.Kills - a.Kills,
                MatchesLost = b.MatchesLost - a.MatchesLost,
                MatchesWon = b.MatchesWon - a.MatchesWon,
                TimePlayed = b.TimePlayed - a.TimePlayed,
                Dbno = b.Dbno - a.Dbno,
                Headshots = b.Headshots - a.Headshots,
                Revives = b.Revives - a.Revives,
                Suicides = b.Suicides - a.Suicides,
                BlindKills = b.BlindKills - a.BlindKills,
                BulletsFired = b.BulletsFired - a.BulletsFired,
                BulletsHit = b.BulletsHit - a.BulletsHit,
                DbnoAssists = b.DbnoAssists - a.DbnoAssists,
                DeniedRevives = b.DeniedRevives - a.DeniedRevives,
                GadgetsDestroyed = b.GadgetsDestroyed - a.GadgetsDestroyed,
                HostagesDefended = b.HostagesDefended - a.HostagesDefended,
                HostagesRescued = b.HostagesRescued - a.HostagesRescued,
                KillAssists = b.KillAssists - a.KillAssists,
                MeleeKills = b.MeleeKills - a.MeleeKills,
                PenetrationKills = b.PenetrationKills - a.PenetrationKills,
                RappelBreaches = b.RappelBreaches - a.RappelBreaches
            };
        }

        private static Dictionary<WeaponType, WeaponStats> CalculateWeaponStatsDelta(Dictionary<WeaponType,WeaponStats> a, Dictionary<WeaponType,WeaponStats> b)
        {
            return b.ToDictionary(kv => kv.Key, kv =>
            {
                WeaponStats bStats = kv.Value;
                WeaponStats aStats = a.ContainsKey(kv.Key) ? a[kv.Key] : new WeaponStats();

                return new WeaponStats
                {
                    Headshots = bStats.Headshots - aStats.Headshots,
                    Kills = bStats.Kills - aStats.Kills,
                    BulletsFired = bStats.BulletsFired - aStats.BulletsFired,
                    BulletsHit = bStats.BulletsHit - aStats.BulletsHit
                };
            });
        }
    }
}