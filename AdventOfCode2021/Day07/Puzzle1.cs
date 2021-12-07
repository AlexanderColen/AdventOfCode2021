using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day07
{
    class Puzzle1 : IPuzzle
    {
        public Puzzle1()
        {
            Console.WriteLine("\nDay 07 - Puzzle 1");
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

            var leastFuel = int.MaxValue;
            foreach (var position in Enumerable.Range(1, numbers.Max()))
            {
                var fuel = 0;
                foreach (var num in numbers.Where(x => x != position))
                {
                    fuel += Math.Abs(position - num);
                }

                leastFuel = fuel < leastFuel ? fuel : leastFuel;
            }

            Console.WriteLine($"Outcome: {leastFuel}");
        }
    }
}
