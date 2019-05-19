using System;
using SiegeApi.Data;
using SiegeApi.Models;

namespace SiegeApi.Utility
{
    public static class FormatUtility
    {
        public static Platform? PlatformFromString(string str)
        {
            switch (str)
            {
                case "uplay": return Platform.Uplay;
                case "steam": return Platform.Steam;
                case "psn": return Platform.PS4;
                case "xbl": return Platform.XboxOne;
            }

            return null;
        }

        public static string PlatformToString(Platform platform)
        {
            switch (platform)
            {
                case Platform.Uplay: return "uplay";
                case Platform.Steam: return "steam";
                case Platform.PS4: return "psn";
                case Platform.XboxOne: return "xbl";
            }

            return platform.ToString();
        }

        public static Region? RegionFromString(string str)
        {
            switch (str)
            {
                case "emea": return Region.Europe;
                case "ncsa": return Region.America;
                case "apac": return Region.Asia;
            }

            return null;
        }

        public static string RegionToString(Region region)
        {
            switch (region)
            {
                case Region.Europe: return "emea";
                case Region.America: return "ncsa";
                case Region.Asia: return "apac";
            }

            return region.ToString();
        }
    }
}