using Newtonsoft.Json;

namespace SiegeApi.Models
{
    public class PvpStats
    {
        public int BlindKills { get; set; }
        public int BulletsFired { get; set; }
        public int BulletsHit { get; set; }
        public int Dbno { get; set; }
        public int DbnoAssists { get; set; }
        public int Deaths { get; set; }
        public int GadgetsDestroyed { get; set; }
        public int Headshots { get; set; }
        public int HostagesDefended { get; set; }
        public int HostagesRescued { get; set; }
        public int KillAssists { get; set; }
        public int Kills { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public int MeleeKills { get; set; }
        public int PenetrationKills { get; set; }
        public int RappelBreaches { get; set; }
        public int Revives { get; set; }
        public int DeniedRevives { get; set; }
        public int Suicides { get; set; }
        public int TimePlayed { get; set; }

        [JsonIgnore]
        public int MatchesPlayed => MatchesLost + MatchesWon;
    }
}