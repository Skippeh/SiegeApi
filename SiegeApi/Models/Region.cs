using Newtonsoft.Json;

namespace SiegeApi.Models
{
    public enum Region
    {
        [JsonProperty("emea")] Europe,
        [JsonProperty("ncsa")] America,
        [JsonProperty("apac")] Asia
    }
}