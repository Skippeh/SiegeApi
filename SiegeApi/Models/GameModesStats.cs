namespace SiegeApi.Models
{
    public class GameModesStats
    {
        public GameModeStats Bomb { get; set; }
        public GameModeStats SecureArea { get; set; }
        public GameModeStats Hostage { get; set; }
    }
}