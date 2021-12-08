using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day08
{
    class Puzzle1 : IPuzzle
    {
        public Puzzle1()
        {
            Console.WriteLine("\nDay 08 - Puzzle 1");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day08/input.txt");
            var uniqueSegments = new int[4] { 2, 3, 4, 7 };
            var count = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                foreach (var segment in line.Split(" | ")[1].Split(' '))
                {
                    if (uniqueSegments.Contains(segment.Length))
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine($"Outcome: {count}");
        }
    }
}
