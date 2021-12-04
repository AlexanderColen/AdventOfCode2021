using System.Collections.Generic;

namespace AdventOfCode2021.Day04
{
    public class Board
    {
        public List<BoardNumber> Numbers { get; }
        public bool hasWon { get; set; }

        public Board()
        {
            this.Numbers = new List<BoardNumber>();
            this.hasWon = false;
        }
    }
}
