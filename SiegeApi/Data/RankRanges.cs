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

            public override string ToString()
            {
                return $"[Range: {MinMmr} - {MaxMmr}]";
            }
        }

        private readonly List<(Range, int)> ranges;

        private Season season;
        
        internal RankRanges(Season season, int[] mmrValues)
        {
            this.season = season ?? throw new ArgumentNullException(nameof(season));
            ranges = new List<(Range, int)>();

            for (int i = 0; i < mmrValues.Length - 1; ++i)
            {
                float currentMmr = mmrValues[i];
                float nextMmr = mmrValues[i + 1];
                
                ranges.Add((new Range(currentMmr, nextMmr), i + 1));
            }

            ranges.Insert(ranges.Count, (new Range(mmrValues[mmrValues.Length - 1], int.MaxValue), mmrValues.Length));
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

            if (mmr < ranges[0].Item1.MinMmr)
                return season.Ranks[ranges[0].Item2];

            throw new ArgumentOutOfRangeException(nameof(mmr));
        }
    }
}