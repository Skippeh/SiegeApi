using System.Collections.Generic;

namespace SiegeApi.Models
{
    public class OperatorStats
    {
        public Operator Operator { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int TimePlayed { get; set; }
        public int RoundsWon { get; set; }
        public int RoundsLost { get; set; }
        public Dictionary<string, int> GadgetStats { get; set; }

        public int RoundsPlayed => RoundsWon + RoundsLost;
    }
}