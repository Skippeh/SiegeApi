using SiegeApi.Data;

namespace SiegeApi.Models
{
    public class Season
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public Rank[] Ranks { get; set; }
        public RankRanges RankRanges { get; set; }
    }
}