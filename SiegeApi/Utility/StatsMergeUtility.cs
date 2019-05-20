using System;
using System.Collections.Generic;
using System.Linq;
using SiegeApi.Models;

namespace SiegeApi.Utility
{
    public static class StatsMergeUtility
    {
        public static UserStats MergeStats(this UserStats target, params UserStats[] stats) => MergeStats(target, (ICollection<UserStats>) stats);

        public static UserStats MergeStats(this UserStats target, ICollection<UserStats> stats)
        {
            return stats.Aggregate(target, (previous, next) => new UserStats
            {
                Operators = MergeOperatorStats(previous.Operators, next.Operators),
                CasualStats = MergeQueueStats(previous.CasualStats, next.CasualStats),
                RankedStats = MergeQueueStats(previous.RankedStats, next.RankedStats),
                GameModes = new GameModesStats
                {
                    Bomb = MergeGameModeStats(previous.GameModes.Bomb, next.GameModes.Bomb),
                    Hostage = MergeGameModeStats(previous.GameModes.Hostage, next.GameModes.Hostage),
                    SecureArea = MergeGameModeStats(previous.GameModes.SecureArea, next.GameModes.SecureArea)
                },
                PvpStats = MergePvpStats(previous.PvpStats, next.PvpStats),
                WeaponStats = MergeWeaponStats(previous.WeaponStats, next.WeaponStats)
            });
        }

        private static List<OperatorStats> MergeOperatorStats(List<OperatorStats> a, List<OperatorStats> b)
        {
            IEnumerable<Operator> allOperators = a.Select(op => op.Operator).Concat(b.Select(op => op.Operator)).Distinct();
            var result = new List<OperatorStats>();

            OperatorStats DefaultStats(Operator op) => new OperatorStats
            {
                Operator = op
            };

            foreach (Operator op in allOperators)
            {
                var aStats = a.FirstOrDefault(stats => stats.Operator == op) ?? DefaultStats(op);
                var bStats = b.FirstOrDefault(stats => stats.Operator == op) ?? DefaultStats(op);
                var allGadgetStats = aStats.GadgetStats.Concat(bStats.GadgetStats).Select(kv => kv.Key).Distinct();

                int GetValue(Dictionary<string, int> stats, string key) => stats.ContainsKey(key) ? stats[key] : 0;

                result.Add(new OperatorStats
                {
                    Deaths = aStats.Deaths + bStats.Deaths,
                    Kills = aStats.Kills + bStats.Kills,
                    RoundsLost = aStats.RoundsLost + bStats.RoundsLost,
                    RoundsWon = aStats.RoundsWon + bStats.RoundsWon,
                    TimePlayed = aStats.TimePlayed + bStats.TimePlayed,
                    GadgetStats = allGadgetStats.ToDictionary(key => key, key => GetValue(aStats.GadgetStats, key) + GetValue(bStats.GadgetStats, key))
                });
            }
            
            return result;
        }

        private static QueueStats MergeQueueStats(QueueStats a, QueueStats b)
        {
            return new QueueStats
            {
                Deaths = a.Deaths + b.Deaths,
                Kills = a.Kills + b.Kills,
                MatchesLost = a.MatchesLost + b.MatchesLost,
                MatchesWon = a.MatchesWon + b.MatchesWon,
                TimePlayed = a.TimePlayed + b.TimePlayed
            };
        }

        private static GameModeStats MergeGameModeStats(GameModeStats a, GameModeStats b)
        {
            return new GameModeStats
            {
                BestScore = a.BestScore + b.BestScore,
                MatchesLost = a.MatchesLost + b.MatchesLost,
                MatchesWon = a.MatchesWon + b.MatchesWon,
                TimePlayed = a.TimePlayed + b.TimePlayed
            };
        }

        private static PvpStats MergePvpStats(PvpStats a, PvpStats b)
        {
            return new PvpStats
            {
                Dbno = a.Dbno + b.Dbno,
                Deaths = a.Deaths + b.Deaths,
                Headshots = a.Headshots + b.Headshots,
                Kills = a.Kills + b.Kills,
                Revives = a.Revives + b.Revives,
                Suicides = a.Suicides + b.Suicides,
                BlindKills = a.BlindKills + b.BlindKills,
                BulletsFired = a.BulletsFired + b.BulletsFired,
                BulletsHit = a.BulletsHit + b.BulletsHit,
                DbnoAssists = a.DbnoAssists + b.DbnoAssists,
                DeniedRevives = a.DeniedRevives + b.DeniedRevives,
                GadgetsDestroyed = a.GadgetsDestroyed + b.GadgetsDestroyed,
                HostagesDefended = a.HostagesDefended + b.HostagesDefended,
                HostagesRescued = a.HostagesRescued + b.HostagesRescued,
                KillAssists = a.KillAssists + b.KillAssists,
                MatchesLost = a.MatchesLost + b.MatchesLost,
                MatchesWon = a.MatchesWon + b.MatchesWon,
                MeleeKills = a.MeleeKills + b.MeleeKills,
                PenetrationKills = a.PenetrationKills + b.PenetrationKills,
                RappelBreaches = a.RappelBreaches + b.RappelBreaches,
                TimePlayed = a.TimePlayed + b.TimePlayed
            };
        }

        private static Dictionary<WeaponType, WeaponStats> MergeWeaponStats(Dictionary<WeaponType,WeaponStats> a, Dictionary<WeaponType,WeaponStats> b)
        {
            return b.ToDictionary(kv => kv.Key, kv => MergeWeaponStats(a[kv.Key], kv.Value));
        }

        private static WeaponStats MergeWeaponStats(WeaponStats a, WeaponStats b)
        {
            return new WeaponStats
            {
                Headshots = a.Headshots + b.Headshots,
                Kills = a.Kills + b.Kills,
                BulletsFired = a.BulletsFired + b.BulletsFired,
                BulletsHit = a.BulletsHit + b.BulletsHit
            };
        }
    }
}