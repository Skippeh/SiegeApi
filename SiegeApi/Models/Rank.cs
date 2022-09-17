namespace SiegeApi.Models
{
    public class Rank
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Rank(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}