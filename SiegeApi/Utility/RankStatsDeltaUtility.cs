using System;
using System.Linq;
using SiegeApi.Models;

namespace SiegeApi.Utility
{
    public static class RankStatsDeltaUtility
    {
        public static RankStats CalculateRankDelta(this RankStats a, RankStats b)
        {
            return new RankStats
            {
                SeasonId = b.SeasonId,
                Rank = b.Rank,
                Abandons = b.Abandons - a.Abandons,
                Losses = b.Losses - a.Losses,
                Mmr = Math.Max(b.Mmr, a.Mmr),
                Wins = b.Wins - a.Wins,
                MaxMmr = Math.Max(b.MaxMmr, a.MaxMmr),
                MaxRank = Math.Max(a.MaxRank, b.MaxRank)
            };
        }
    }
}