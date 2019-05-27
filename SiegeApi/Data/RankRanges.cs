using System;
using System.Collections.Generic;
using SiegeApi.Models;

namespace SiegeApi.Data
{
    public class RankRanges
    {
        private class Range
        {
            public readonly float MinMmr;
            public readonly float MaxMmr;

            public Range(float minMmr, float maxMmr)
            {
                MinMmr = minMmr;
                MaxMmr = maxMmr;
            }
        }

        private readonly List<(Range, int)> ranges = new List<(Range, int)>
        {
            (new Range(int.MinValue, 1399), 1), // Copper 4
            (new Range(1400, 1499), 2), // Copper 3
            (new Range(1500, 1599), 3), // Copper 2
            (new Range(1600, 1699), 4), // Copper 1
            (new Range(1700, 1799), 5), // Bronze 4
            (new Range(1800, 1899), 6), // Bronze 3
            (new Range(1900, 1999), 7), // Bronze 2
            (new Range(2000, 2099), 8), // Bronze 1
            (new Range(2100, 2199), 9), // Silver 4
            (new Range(2200, 2299), 10), // Silver 3
            (new Range(2300, 2399), 11), // Silver 2
            (new Range(2400, 2499), 12), // Silver 1
            (new Range(2500, 2699), 13), // Gold 4
            (new Range(2700, 2899), 14), // Gold 3
            (new Range(2900, 3099), 15), // Gold 2
            (new Range(3100, 3299), 16), // Gold 1
            (new Range(3300, 3699), 17), // Platinum 3
            (new Range(3700, 4099), 18), // Platinum 2
            (new Range(4100, 4499), 19), // Platinum 1
            (new Range(4500, Int32.MaxValue), 20) // Diamond
        };
        
        internal RankRanges()
        {
        }

        public Rank GetRank(float mmr)
        {
            mmr = (float) Math.Floor(mmr);
            
            for (int i = 0; i < ranges.Count; ++i)
            {
                Range range = ranges[i].Item1;

                if (range.MinMmr <= mmr && range.MaxMmr >= mmr)
                    return Ranks.Data[ranges[i].Item2];
            }

            throw new ArgumentOutOfRangeException(nameof(mmr));
        }
    }
}