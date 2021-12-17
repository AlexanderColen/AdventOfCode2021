using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day12
{
    public class Cave
    {
        public string Name { get; }
        public bool IsLarge { get; }
        public List<Cave> Connections { get; }

        public Cave(string name, bool isLarge)
        {
            this.Name = name;
            this.IsLarge = isLarge;
            this.Connections = new List<Cave>();
        }

        public override string ToString()
        {
            return $"{this.Name} - Large: {this.IsLarge} - Connects to: {string.Join(',', this.Connections.Select(x => x.Name))}";
        }
    }
}
