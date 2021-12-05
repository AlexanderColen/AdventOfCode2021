using System;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("TODO: Run all puzzles dynamically using file search?");
                
                new Day01.Puzzle1();
                new Day01.Puzzle2();
                new Day02.Puzzle1();
                new Day02.Puzzle2();
                new Day03.Puzzle1();
                new Day03.Puzzle2();
                new Day04.Puzzle1();
                new Day04.Puzzle2();
                new Day05.Puzzle1();
                new Day05.Puzzle2();
            } else
            {
                Console.WriteLine("TODO: Smart way to determine which puzzle to run using command line arguments.");
            }
        }
    }
}
