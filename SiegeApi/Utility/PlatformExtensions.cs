using SiegeApi.Data;

namespace SiegeApi.Utility
{
    public static class PlatformExtensions
    {
        /// <summary>
        /// Returns true if the two platform values match each other, or if a and b are both on PC, or vice versa.
        /// </summary>
        public static bool Matches(this Platform a, Platform b)
        {
            return a == b ||
                   PlatformIsPC(a) && PlatformIsPC(b);
        }

        private static bool PlatformIsPC(Platform platform)
        {
            return platform == Platform.Steam ||
                   platform == Platform.Uplay ||
                   platform == Platform.EpicGames;
        }
    }
}