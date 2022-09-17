using System.Collections.Generic;
using Newtonsoft.Json;
using SiegeApi.Models;

namespace SiegeApi.Requests.ResponseModels
{
    public class RankResponse
    {
        public class ResponseRankStats
        {
            public int Abandons { get; set; }
            public int Losses { get; set; }
            [JsonProperty("max_mmr")]
            public float MaxMmr { get; set; }
            [JsonProperty("max_rank")]
            public int MaxRank { get; set; }
            public float Mmr { get; set; }
            public int Rank { get; set; }
            public string Region { get; set; } = null!;
            public int Season { get; set; }
            public int Wins { get; set; }
        }
        
        public Dictionary<string, ResponseRankStats> Players { get; set; } = null!;
    }
}