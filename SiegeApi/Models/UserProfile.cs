using System;
using Newtonsoft.Json;
using SiegeApi.Data;
using SiegeApi.Utility;

namespace SiegeApi.Models
{
    public class UserProfile
    {
        public string NameOnPlatform { get; set; }

        public Platform Platform
        {
            get => FormatUtility.PlatformFromString(platform) ?? throw new NotImplementedException();
            set => platform = FormatUtility.PlatformToString(value);
        }

        public Guid UserId { get; set; }
        
        public Guid ProfileId { get; set; }

        [JsonProperty("platformType")]
        private string platform { get; set; }
    }
}