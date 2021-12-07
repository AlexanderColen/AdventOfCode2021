using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day07
{
    class Puzzle2 : IPuzzle
    {
        public Puzzle2()
        {
            Console.WriteLine("\nDay 07 - Puzzle 2");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day07/input.txt");
            var numbers = new List<int>();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                foreach (var num in line.Split(','))
                {
                    numbers.Add(int.Parse(num));
                }
            }

            numbers.Sort();

            var leastFuel = long.MaxValue;
            foreach (var position in Enumerable.Range(1, numbers.Max()))
            {
                long fuel = 0;
                foreach (var num in numbers.Where(x => x != position))
                {
                    var diff = Math.Abs(position - num);
                    fuel += diff * (diff + 1) / 2;
                }

                leastFuel = fuel < leastFuel ? fuel : leastFuel;
            }

            Console.WriteLine($"Outcome: {leastFuel}");
        }
    }
}
