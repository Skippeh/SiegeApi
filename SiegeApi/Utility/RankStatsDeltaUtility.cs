using SiegeApi.Models;

namespace SiegeApi.Utility
{
    public static class RankStatsDeltaUtility
    {
        public static RankStats CalculateRankDelta(this RankStats a, RankStats b)
        {
            return new RankStats
            {
                Season = b.Season,
                Rank = b.Rank,
                Abandons = b.Abandons - a.Abandons,
                Losses = b.Losses - a.Losses,
                Mmr = b.Mmr - a.Mmr,
                Wins = b.Wins - a.Wins,
                MaxMmr = b.MaxMmr - a.MaxMmr,
                MaxRank = b.MaxRank - a.MaxRank
            };
        }
    }
}