using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2021.Day01
{
    class Puzzle1 : IPuzzle
    {
        public Puzzle1()
        {
            Console.WriteLine("\nDay 01 - Puzzle 1");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day01/input.txt");
            var increments = 0;
            int? previous = null;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                int current = int.Parse(line);
                if (previous != null && current > previous)
                {
                    increments++;
                }

                previous = current;
            }

            Console.WriteLine($"Outcome: {increments}");
        }
    }
}
