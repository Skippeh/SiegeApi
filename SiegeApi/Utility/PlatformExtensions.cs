using SiegeApi.Data;

namespace SiegeApi.Utility
{
    public static class PlatformExtensions
    {
        /// <summary>
        /// Returns true if the two platform values match each other, or if a is Steam and b is Uplay, or vice versa.
        /// </summary>
        public static bool Matches(this Platform a, Platform b)
        {
            return a == b ||
                   a == Platform.Steam && b == Platform.Uplay ||
                   b == Platform.Steam && a == Platform.Uplay;
        }
    }
}