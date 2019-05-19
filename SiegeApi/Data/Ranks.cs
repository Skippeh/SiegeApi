using System.Linq;
using SiegeApi.Models;

namespace SiegeApi.Data
{
    public static class Ranks
    {
        public static readonly Rank[] Data = new[]
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
            "Diamond",
            "Diamond+"
        }.Select((name, index) => new Rank
        {
            Id = index,
            Name = name
        }).ToArray();
    }
}