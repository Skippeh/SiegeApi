using System.Collections.Generic;

namespace SiegeApi.Models
{
    public class UserStats
    {
        public List<OperatorStats> Operators { get; set; } = null!;
        public QueueStats CasualStats { get; set; } = null!;
        public QueueStats RankedStats { get; set; } = null!;
        public PvpStats PvpStats { get; set; } = null!;
        public GameModesStats GameModes { get; set; } = null!;
        public Dictionary<WeaponType, WeaponStats> WeaponStats { get; set; } = null!;
    }
}