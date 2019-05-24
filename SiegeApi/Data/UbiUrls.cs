using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SiegeApi.Models;
using SiegeApi.Utility;

namespace SiegeApi.Data
{
    internal class UbiUrls
    {
        public const string LoginUrl = "https://uplayconnect.ubi.com/ubiservices/v2/profiles/sessions?";
        public const string ReverseUrl = "https://public-ubiservices.ubi.com/v2/profiles?userId=";

        public static readonly ReadOnlyDictionary<Platform, PlatformUrls> Urls = new ReadOnlyDictionary<Platform, PlatformUrls>(new Dictionary<Platform, PlatformUrls>
        {
            {
                Platform.Uplay,
                new PlatformUrls
                {
                    ProfileUrl = "https://public-ubiservices.ubi.com/v2/profiles?platformType=uplay&nameOnPlatform=",
                    StatsUrl = "https://public-ubiservices.ubi.com/v1/spaces/5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/playerstats2/statistics?",
                    LevelUrl = "https://public-ubiservices.ubi.com/v1/spaces/5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/r6playerprofile/playerprofile/progressions?profile_ids=",
                    RankUrl = "https://public-ubiservices.ubi.com/v1/spaces/5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/r6karma/players?board_id=pvp_ranked&"
                }
            },
            {
                Platform.Steam,
                new PlatformUrls
                {
                    ProfileUrl = "https://public-ubiservices.ubi.com/v2/profiles?platformType=uplay&nameOnPlatform=",
                    StatsUrl = "https://public-ubiservices.ubi.com/v1/spaces/5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/playerstats2/statistics?",
                    LevelUrl = "https://public-ubiservices.ubi.com/v1/spaces/5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/r6playerprofile/playerprofile/progressions?profile_ids=",
                    RankUrl = "https://public-ubiservices.ubi.com/v1/spaces/5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/r6karma/players?board_id=pvp_ranked&"
                }
            },
            {
                Platform.PS4,
                new PlatformUrls
                {
                    ProfileUrl = "https://public-ubiservices.ubi.com/v2/profiles?platformType=psn&nameOnPlatform=",
                    StatsUrl = "https://public-ubiservices.ubi.com/v1/spaces/05bfb3f7-6c21-4c42-be1f-97a33fb5cf66/sandboxes/OSBOR_PS4_LNCH_A/playerstats2/statistics?",
                    LevelUrl = "https://public-ubiservices.ubi.com/v1/spaces/05bfb3f7-6c21-4c42-be1f-97a33fb5cf66/sandboxes/OSBOR_PS4_LNCH_A/r6playerprofile/playerprofile/progressions?profile_ids=",
                    RankUrl = "https://public-ubiservices.ubi.com/v1/spaces/05bfb3f7-6c21-4c42-be1f-97a33fb5cf66/sandboxes/OSBOR_PS4_LNCH_A/r6karma/players?board_id=pvp_ranked&"
                }
            },
            {
                Platform.XboxOne,
                new PlatformUrls
                {
                    ProfileUrl = "https://public-ubiservices.ubi.com/v2/profiles?platformType=xbl&nameOnPlatform=",
                    StatsUrl = "https://public-ubiservices.ubi.com/v1/spaces/98a601e5-ca91-4440-b1c5-753f601a2c90/sandboxes/OSBOR_XBOXONE_LNCH_A/playerstats2/statistics?",
                    LevelUrl = "https://public-ubiservices.ubi.com/v1/spaces/98a601e5-ca91-4440-b1c5-753f601a2c90/sandboxes/OSBOR_XBOXONE_LNCH_A/r6playerprofile/playerprofile/progressions?profile_ids=",
                    RankUrl = "https://public-ubiservices.ubi.com/v1/spaces/98a601e5-ca91-4440-b1c5-753f601a2c90/sandboxes/OSBOR_XBOXONE_LNCH_A/r6karma/players?board_id=pvp_ranked&"
                }
            }
        });

        public static string GetProfileUrl(Platform platform, string name) => Urls[platform].ProfileUrl + Uri.EscapeUriString(name);

        public static string GetStatsUrl(Platform platform, string[] stats, params Guid[] userIds) =>
            Urls[platform].StatsUrl + $"statistics={string.Join(",", stats.Select(Uri.EscapeUriString))}&populations={string.Join(",", userIds)}";

        public static string GetLevelUrl(Platform platform, params Guid[] profileIds) => Urls[platform].LevelUrl + string.Join(",", profileIds);
        public static string GetReverseUrl(Guid profileId) => ReverseUrl + profileId;

        public static string GetRankUrl(Platform platform, Region region, int seasonId, params Guid[] userIds)
        {
            return $"{Urls[platform].RankUrl}season_id={seasonId}&profile_ids={string.Join(",", userIds)}&region_id={GetRegionId(region)}";
        }

        private static string GetRegionId(Region region)
        {
            return FormatUtility.RegionToString(region);
        }

        private static Region GetRegion(string regionId)
        {
            return FormatUtility.RegionFromString(regionId) ?? throw new NotImplementedException();
        }
    }

    internal class PlatformUrls
    {
        public string ProfileUrl;
        public string StatsUrl;
        public string LevelUrl;
        public string RankUrl;
    }
}