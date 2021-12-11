namespace AdventOfCode2021.Day11
{
    public class Octopus
    {
        public int X { get ; }
        public int Y { get; }
        public int Energy { get; set; }
        public bool HasFlashed { get; set; }

        public Octopus(int x, int y, int energy)
        {
            this.X = x;
            this.Y = y;
            this.Energy = energy;
            this.HasFlashed = false;
        }

        public void Reset()
        {
            this.Energy = 0;
            this.HasFlashed = false;
        }

        public override string ToString()
        {
            return $"[{this.X},{this.Y}] - Energy level: {this.Energy} - Flashed this step: {this.HasFlashed}";
        }
    }
}
