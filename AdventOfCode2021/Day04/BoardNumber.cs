namespace AdventOfCode2021.Day04
{
    public class BoardNumber
    {
        public int X { get; }
        public int Y { get; }
        public string Number { get; }
        public bool Marked { get; set; }

        public BoardNumber(int X, int Y, string Number)
        {
            this.X = X;
            this.Y = Y;
            this.Number = Number;
            this.Marked = false;
        }

        public override string ToString()
        {
            return $"[{this.X},{this.Y}] - {this.Number} - {(this.Marked ? "Marked" : "Unmarked")}";
        }
    }
}
