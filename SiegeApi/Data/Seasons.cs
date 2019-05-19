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
            "Burnt Horizon"
        }.Select((name, index) => new Season
        {
            Id = index + 1,
            Index = index,
            Name = name
        }).ToArray();

        public static Season CurrentSeason => Data[Data.Length - 1];
    }
}