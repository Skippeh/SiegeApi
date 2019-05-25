using System;
using SiegeApi.Models;

namespace SiegeApi.Utility
{
    public static class LevelUtility
    {
        public static int GetLevelXp(int level) => 5000 + (Math.Max(level - 2, 0) * 500);

        public static float GetLevelProgress(this ProfileProgression progression) => GetLevelProgress(progression.Xp, progression.Level);

        public static float GetLevelProgress(int xp, int level) => (float) xp / GetLevelXp(level + 1);
    }
}