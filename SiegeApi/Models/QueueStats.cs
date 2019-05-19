namespace SiegeApi.Models
{
    public class QueueStats
    {
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public int TimePlayed { get; set; }

        public int MatchesPlayed => MatchesLost + MatchesWon;
    }
}