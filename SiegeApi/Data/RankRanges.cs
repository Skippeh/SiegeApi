using System;
using System.Collections.Generic;
using System.Linq;
using SiegeApi.Models;

namespace SiegeApi.Data
{
    public class RankRanges
    {
        public class Range
        {
            public readonly float MinMmr;
            public readonly float MaxMmr;

            public Range(float minMmr, float maxMmr)
            {
                MinMmr = minMmr;
                MaxMmr = maxMmr;
            }
        }

        private readonly List<(Range, int)> ranges;

        private Season season;
        
        internal RankRanges(Season season, int[] mmrValues)
        {
            this.season = season ?? throw new ArgumentNullException(nameof(season));
            ranges = new List<(Range, int)>();

            for (int i = 0; i < mmrValues.Length; ++i)
            {
                float currentMmr = i == 0 ? int.MinValue : mmrValues[i];
                float nextMmr = i == 0 ? mmrValues[0] : i >= mmrValues.Length - 1 ? int.MaxValue : mmrValues[i + 1];
                ranges.Add((new Range(currentMmr, nextMmr), i + 1));
            }
        }

        public Rank GetRank(float mmr)
        {
            mmr = (float) Math.Floor(mmr);
            
            for (int i = ranges.Count - 1; i >= 0; --i)
            {
                Range range = ranges[i].Item1;

                if (range.MinMmr <= mmr && range.MaxMmr >= mmr)
                    return season.Ranks[ranges[i].Item2];
            }

            throw new ArgumentOutOfRangeException(nameof(mmr));
        }
    }
}