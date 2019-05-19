using SiegeApi.Models;

namespace SiegeApi.Tests
{
    public static class Singletons
    {
        public static SiegeApiClient ApiClient;
        public static UserProfile UserProfile;
        public static readonly object MonitorObject = new object();
    }
}