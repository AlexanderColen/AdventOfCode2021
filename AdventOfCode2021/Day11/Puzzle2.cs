using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day11
{
    class Puzzle2 : IPuzzle
    {
        public Puzzle2()
        {
            Console.WriteLine("\nDay 11 - Puzzle 2");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day11/input.txt");
            var octopodes = new List<Octopus>();
            string line;
            var row = 0;
            while ((line = sr.ReadLine()) != null)
            {
                for (var i = 0; i < line.Length; i++)
                {
                    octopodes.Add(new Octopus(i, row, int.Parse(line[i].ToString())));
                }
                row++;
            }

            var step = 0;
            while (octopodes.Count(x => x.Energy >= 10) != octopodes.Count())
            {
                // Reset the flashed octopodes.
                foreach (var octopus in octopodes.Where(x => x.HasFlashed))
                {
                    octopus.Reset();
                }

                step++;

                // Increase every octopus' energy level.
                foreach (var octopus in octopodes)
                {
                    octopus.Energy++;
                }

                octopodes = FlashOctopodes(octopodes);
            }

            Console.WriteLine($"Outcome: {step}");
        }

        private List<Octopus> FlashOctopodes(List<Octopus> octopodes)
        {
            foreach (var octopus in octopodes)
            {
                if (octopus.Energy >= 10 && !octopus.HasFlashed)
                {
                    octopus.HasFlashed = true;

                    // Up
                    if (octopus.Y > 0)
                    {
                        octopodes.Where(x => x.X == octopus.X && x.Y == octopus.Y - 1).First().Energy++;
                    }
                    // Down
                    if (octopus.Y < 9)
                    {
                        octopodes.Where(x => x.X == octopus.X && x.Y == octopus.Y + 1).First().Energy++;
                    }
                    // Left
                    if (octopus.X > 0)
                    {
                        octopodes.Where(x => x.X == octopus.X - 1 && x.Y == octopus.Y).First().Energy++;
                    }
                    // Right
                    if (octopus.X < 9)
                    {
                        octopodes.Where(x => x.X == octopus.X + 1 && x.Y == octopus.Y).First().Energy++;
                    }
                    // Diagonal up left
                    if (octopus.X > 0 && octopus.Y > 0)
                    {
                        octopodes.Where(x => x.X == octopus.X - 1&& x.Y == octopus.Y - 1).First().Energy++;
                    }
                    // Diagonal up right
                    if (octopus.X < 9 && octopus.Y > 0)
                    {
                        octopodes.Where(x => x.X == octopus.X + 1 && x.Y == octopus.Y - 1).First().Energy++;
                    }
                    // Diagonal down left
                    if (octopus.X > 0 && octopus.Y < 9)
                    {
                        octopodes.Where(x => x.X == octopus.X - 1 && x.Y == octopus.Y + 1).First().Energy++;
                    }
                    // Diagonal down right
                    if (octopus.X < 9 && octopus.Y < 9)
                    {
                        octopodes.Where(x => x.X == octopus.X + 1 && x.Y == octopus.Y + 1).First().Energy++;
                    }

                   octopodes = FlashOctopodes(octopodes);
                }
            }

            return octopodes;
        }
    }
}
