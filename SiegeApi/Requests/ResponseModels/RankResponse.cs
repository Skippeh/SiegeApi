using System.Collections.Generic;
using SiegeApi.Models;

namespace SiegeApi.Requests.ResponseModels
{
    public class RankResponse
    {
        public Dictionary<string, RankStats> Players { get; set; }
    }
}