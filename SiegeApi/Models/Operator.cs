namespace SiegeApi.Models
{
    public class Operator
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ReadableName { get; set; }
        public string FullIndex { get; set; }
        public string[] Gadgets { get; set; } = new string[0];
        public TeamType Team { get; set; }
    }
}