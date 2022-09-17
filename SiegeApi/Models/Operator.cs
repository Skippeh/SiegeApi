using System;

namespace SiegeApi.Models
{
    public class Operator
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string ReadableName { get; set; } = null!;
        public string? FullIndex { get; set; }
        public string[] Gadgets { get; set; } = Array.Empty<string>();
        public TeamType Team { get; set; }
    }
}