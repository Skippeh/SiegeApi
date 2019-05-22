using System;
using Newtonsoft.Json;
using SiegeApi.Data;
using SiegeApi.Utility;

namespace SiegeApi.Models
{
    public class RankStats
    {
        public int Abandons { get; set; }
        public int Losses { get; set; }
        [JsonProperty("max_mmr")] public float MaxMmr { get; set; }
        [JsonProperty("max_rank")] public int MaxRank { get; set; }
        public float Mmr { get; set; }
        public Rank Rank
        {
            get => Ranks.Data[rank];
            set => rank = value.Id;
        }

        public Region Region
        {
            get => FormatUtility.RegionFromString(region) ?? throw new NotImplementedException();
            set => region = FormatUtility.RegionToString(value);
        }
        public Season Season
        {
            get => Seasons.Data[season - 1];
            set => season = value.Index;
        }

        public int Wins { get; set; }

        [JsonProperty]
        private int season { get; set; }
        
        [JsonProperty]
        private string region { get; set; }
        
        [JsonProperty]
        private int rank { get; set; }
    }
}