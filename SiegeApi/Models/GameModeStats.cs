using Newtonsoft.Json;

namespace SiegeApi.Models
{
    public class GameModeStats
    {
        public int BestScore { get; set; }
        public int MatchesLost { get; set; }
        public int MatchesWon { get; set; }
        public int TimePlayed { get; set; }

        [JsonIgnore]
        public int MatchesPlayed => MatchesLost + MatchesWon;
    }
}