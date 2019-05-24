using System.Collections.Generic;

namespace SiegeApi.Models
{
    public class UserStats
    {
        public List<OperatorStats> Operators { get; set; }
        public QueueStats CasualStats { get; set; }
        public QueueStats RankedStats { get; set; }
        public PvpStats PvpStats { get; set; }
        public GameModesStats GameModes { get; set; }
        public Dictionary<WeaponType, WeaponStats> WeaponStats { get; set; }
        public ProfileProgression Progression { get; set; }
    }
}