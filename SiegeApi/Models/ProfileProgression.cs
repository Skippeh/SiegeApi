using System;
using Newtonsoft.Json;

namespace SiegeApi.Models
{
    public class ProfileProgression
    {
        public int Xp { get; set; }
        public int LootboxProbability { get; set; }
        public int Level { get; set; }

        public float LootboxChance => LootboxProbability / 10_000f;

        [JsonIgnore]
        public int LootboxPercentage => (int) Math.Round(LootboxChance * 100f);
    }
}