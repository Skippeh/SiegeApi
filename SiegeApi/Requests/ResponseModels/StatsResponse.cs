using System.Collections.Generic;

namespace SiegeApi.Requests.ResponseModels
{
    public class StatsResponse
    {
        public Dictionary<string, Dictionary<string, int>> Results { get; set; } = null!;
    }
}