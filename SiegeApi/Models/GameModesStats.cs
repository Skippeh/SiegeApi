namespace SiegeApi.Models
{
    public class GameModesStats
    {
        public GameModeStats Bomb { get; set; } = null!;
        public GameModeStats SecureArea { get; set; } = null!;
        public GameModeStats Hostage { get; set; } = null!;
    }
}