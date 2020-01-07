using SiegeApi.Data;
using SiegeApi.Utility;

namespace SiegeApi.Models
{
    public class RankStats
    {
        public int Abandons { get; set; }
        public int Losses { get; set; }
        public float MaxMmr { get; set; }
        public Rank MaxRank { get; set; }
        public float Mmr { get; set; }
        public Rank Rank { get; set; }
        public Region Region { get; set; }
        public Season Season { get; set; }
        public int Wins { get; set; }
        public int GamesPlayed => Wins + Losses;

        public Rank GetRankFromMmr()
        {
            return Season.RankRanges.GetRank(Mmr);
        }

        public Rank GetRankFromMaxMmr()
        {
            return Season.RankRanges.GetRank(MaxMmr);
        }
    }
}