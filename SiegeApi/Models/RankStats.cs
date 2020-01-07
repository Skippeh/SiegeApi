using Newtonsoft.Json;
using SiegeApi.Data;
using SiegeApi.Utility;

namespace SiegeApi.Models
{
    public class RankStats
    {
        public int Abandons { get; set; }
        public int Losses { get; set; }
        public float MaxMmr { get; set; }

        [JsonIgnore]
        public Rank MaxRank { get; set; }

        public float Mmr { get; set; }

        [JsonIgnore]
        public Rank Rank { get; set; }

        public Region Region { get; set; }

        [JsonIgnore]
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