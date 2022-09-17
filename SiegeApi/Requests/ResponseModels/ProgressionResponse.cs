using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SiegeApi.Requests.ResponseModels
{
    public class ProgressionResponse
    {
        public class ProfileProgressionResponse
        {
            public int Xp { get; set; }

            [JsonProperty("profile_id")]
            public Guid ProfileId { get; set; }

            [JsonProperty("lootbox_probability")]
            public int LootboxProbability { get; set; }

            public int Level { get; set; }
        }
        
        [JsonProperty("player_profiles")]
        public List<ProfileProgressionResponse> UserProfiles { get; set; } = null!;
    }
}