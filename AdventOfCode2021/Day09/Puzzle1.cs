using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day09
{
    class Puzzle1 : IPuzzle
    {
        public Puzzle1()
        {
            Console.WriteLine("\nDay 09 - Puzzle 1");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day09/input.txt");
            var grid = new List<int[]>();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var row = new int[line.Length];
                for (var x = 0; x < line.Length; x++)
                {
                    row[x] = int.Parse(line[x].ToString());
                }
                grid.Add(row);
            }

            var risk = 0;
            for (var y = 0; y < grid.Count; y++)
            {
                for (var x = 0; x < grid[y].Length; x++)
                {
                    // Left
                    if (x > 0)
                    {
                        if (grid[y][x - 1] <= grid[y][x])
                        {
                            continue;
                        }
                    }

                    // Right
                    if (x < grid[y].Length - 1)
                    {
                        if (grid[y][x + 1] <= grid[y][x])
                        {
                            continue;
                        }
                    }

                    // Above
                    if (y > 0)
                    {
                        if (grid[y - 1][x] <= grid[y][x])
                        {
                            continue;
                        }
                    }

                    // Below
                    if (y < grid.Count - 1)
                    {
                        if (grid[y + 1][x] <= grid[y][x])
                        {
                            continue;
                        }
                    }

                    // Reaching this means all neighbours are higher.
                    risk += 1 + grid[y][x];
                }
            }

            Console.WriteLine($"Outcome: {risk}");
        }
    }
}
