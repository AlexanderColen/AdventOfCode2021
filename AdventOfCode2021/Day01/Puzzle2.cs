using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2021.Day01
{
    class Puzzle2 : IPuzzle
    {
        public Puzzle2()
        {
            Console.WriteLine("\nDay 01 - Puzzle 2");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day01/input.txt");
            var increments = 0;
            int? previous1 = null;
            int? previous2 = null;
            int? previous3 = null;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                int current = int.Parse(line);
                if (previous1 != null && previous2 != null && previous3 != null && (current + previous2 + previous3) > (previous1 + previous2 + previous3))
                {
                    increments++;
                }

                previous1 = previous2;
                previous2 = previous3;
                previous3 = current;
            }

            Console.WriteLine($"Outcome: {increments}");
        }
    }
}
