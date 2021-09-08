using System;
using System.Collections.Generic;
using System.Linq;
using SiegeApi.Models;

namespace SiegeApi.Data
{
    public static class Seasons
    {
        public static readonly Season[] Data = new[]
        {
            "Release",
            "Dust Line",
            "Skull Rain",
            "Red Crow",
            "Velvet Shell",
            "Health",
            "Blood Orchid",
            "White Noise",
            "Chimera",
            "Para Bellum",
            "Grim Sky",
            "Wind Bastion",
            "Burnt Horizon",
            "Phantom Sight",
            "Ember Rise",
            "Shifting Tides",
            "Void Edge",
            "Steel Wave",
            "Shadow Legacy",
            "Neon Dawn",
            "Crimson Heist",
            "North Star",
            "Crystal Guard",
        }.Select((name, index) =>
        {
            var result = new Season
            {
                Id = index + 1,
                Index = index,
                Name = name,
                Ranks = CreateRanks(index + 1)
            };

            result.RankRanges = CreateRanges(result);
            return result;
        }).ToArray();

        public static Season CurrentSeason => Data[Data.Length - 1];

        private static Rank[] CreateRanks(int seasonId)
        {
            switch (seasonId)
            {
                case int _ when (seasonId >= 1 && seasonId <= 4): // Season 1 to 4
                    return CreateRanksFromNames(new[]
                    {
                        "Unranked",
                        "Copper 1",
                        "Copper 2",
                        "Copper 3",
                        "Copper 4",
                        "Bronze 1",
                        "Bronze 2",
                        "Bronze 3",
                        "Bronze 4",
                        "Silver 1",
                        "Silver 2",
                        "Silver 3",
                        "Silver 4",
                        "Gold 1",
                        "Gold 2",
                        "Gold 3",
                        "Gold 4",
                        "Platinum 1",
                        "Platinum 2",
                        "Platinum 3",
                        "Diamond"
                    });
                case int _ when (seasonId >= 5 && seasonId <= 15): // Season 5 to 15
                    return CreateRanksFromNames(new[]
                    {
                        "Unranked",
                        "Copper 4",
                        "Copper 3",
                        "Copper 2",
                        "Copper 1",
                        "Bronze 4",
                        "Bronze 3",
                        "Bronze 2",
                        "Bronze 1",
                        "Silver 4",
                        "Silver 3",
                        "Silver 2",
                        "Silver 1",
                        "Gold 4",
                        "Gold 3",
                        "Gold 2",
                        "Gold 1",
                        "Platinum 3",
                        "Platinum 2",
                        "Platinum 1",
                        "Diamond"
                    });
                default: // Latest rank should always be default
                    return CreateRanksFromNames(new[]
                    {
                        "Unranked",
                        "Copper 5",
                        "Copper 4",
                        "Copper 3",
                        "Copper 2",
                        "Copper 1",
                        "Bronze 5",
                        "Bronze 4",
                        "Bronze 3",
                        "Bronze 2",
                        "Bronze 1",
                        "Silver 5",
                        "Silver 4",
                        "Silver 3",
                        "Silver 2",
                        "Silver 1",
                        "Gold 3",
                        "Gold 2",
                        "Gold 1",
                        "Platinum 3",
                        "Platinum 2",
                        "Platinum 1",
                        "Diamond",
                        "Champions"
                    });
            }
        }

        private static RankRanges CreateRanges(Season season)
        {
            switch (season.Id)
            {
                case int _ when (season.Id >= 1 && season.Id <= 3): // Season 1 to 3
                    return new RankRanges(season, new []
                    {
                        2100, // Copper 1
                        2200, // Copper 2
                        2400, // Copper 3
                        2550, // Copper 4
                        2700, // Bronze 1
                        2800, // Bronze 2
                        2900, // Bronze 3
                        3050, // Bronze 4
                        3200, // Silver 1
                        3350, // Silver 2
                        3520, // Silver 3
                        3700, // Silver 4
                        3930, // Gold 1
                        4160, // Gold 2
                        4400, // Gold 3
                        4640, // Gold 4
                        4900, // Platinum 1
                        5160, // Platinum 2
                        5450, // Platinum 3
                        6000  // Diamond
                    });
                case 4:
                    return new RankRanges(season, new []
                    {
                        1300, // Copper 1
                        1400, // Copper 2
                        1500, // Copper 3
                        1600, // Copper 4
                        1700, // Bronze 1
                        1800, // Bronze 2
                        1900, // Bronze 3
                        2000, // Bronze 4
                        2100, // Silver 1
                        2200, // Silver 2
                        2300, // Silver 3
                        2400, // Silver 4
                        2500, // Gold 1
                        2600, // Gold 2
                        2700, // Gold 3
                        2800, // Gold 4
                        3000, // Platinum 1
                        3200, // Platinum 2
                        3400, // Platinum 3
                        3700  // Diamond
                    });
                case int _ when (season.Id >= 5 && season.Id <= 14): // Season 5 to 14
                    return new RankRanges(season, new []
                    {
                        1300, // Copper 4
                        1400, // Copper 3
                        1500, // Copper 2
                        1600, // Copper 1
                        1700, // Bronze 4
                        1800, // Bronze 3
                        1900, // Bronze 2
                        2000, // Bronze 1
                        2100, // Silver 4
                        2200, // Silver 3
                        2300, // Silver 2
                        2400, // Silver 1
                        2500, // Gold 4
                        2700, // Gold 3
                        2900, // Gold 2
                        3100, // Gold 1
                        3300, // Platinum 3
                        3700, // Platinum 2
                        4100, // Platinum 1
                        4500  // Diamond
                    });
                case 15:
                    return new RankRanges(season, new []
                    {
                        1200, // Copper 4
                        1300, // Copper 3
                        1400, // Copper 2
                        1500, // Copper 1
                        1600, // Bronze 4
                        1700, // Bronze 3
                        1800, // Bronze 2
                        1900, // Bronze 1
                        2000, // Silver 4
                        2100, // Silver 3
                        2200, // Silver 2
                        2300, // Silver 1
                        2400, // Gold 4
                        2500, // Gold 3
                        2600, // Gold 2
                        2800, // Gold 1
                        3000, // Platinum 3
                        3200, // Platinum 2
                        3600, // Platinum 1
                        4000  // Diamond
                    });
                default: // Latest season should always be default
                    return new RankRanges(season, new[]
                    {
                        1100, // Copper 5
                        1200, // Copper 4
                        1300, // Copper 3
                        1400, // Copper 2
                        1500, // Copper 1
                        1600, // Bronze 5
                        1700, // Bronze 4
                        1800, // Bronze 3
                        1900, // Bronze 2
                        2000, // Bronze 1
                        2100, // Silver 5
                        2200, // Silver 4
                        2300, // Silver 3
                        2400, // Silver 2
                        2500, // Silver 1
                        2600, // Gold 3
                        2800, // Gold 2
                        3000, // Gold 1
                        3200, // Platinum 3
                        3600, // Platinum 2
                        4000, // Platinum 1
                        4400, // Diamond
                        5000 // Champions
                    });
            }
        }

        private static Rank[] CreateRanksFromNames(string[] rankNames)
        {
            return rankNames.Select((name, index) => new Rank
            {
                Id = index,
                Name = name
            }).ToArray();
        }
    }
}