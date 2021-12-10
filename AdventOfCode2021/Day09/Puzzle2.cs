using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day09
{
    class Puzzle2 : IPuzzle
    {
        public Puzzle2()
        {
            Console.WriteLine("\nDay 09 - Puzzle 2");
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

            grid = ExpandGrid(grid);

            var lowPoints = new List<Tuple<int, int>>();
            for (var y = 1; y < grid.Count - 1; y++)
            {
                for (var x = 1; x < grid[y].Length - 1; x++)
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
                    lowPoints.Add(new Tuple<int, int>(x, y));
                }
            }

            var basins = new List<long>();
            foreach (var point in lowPoints)
            {
                basins.Add(DetermineBasin(grid, point, new List<Tuple<int, int>>()).Count);
            }

            basins.Sort();

            Console.WriteLine($"Outcome: {basins[^1] * basins[^2] * basins[^3]}");
        }
        
        // Expand grid by adding a border of 9s.
        private List<int[]> ExpandGrid(List<int[]> grid)
        {
            var expandedGrid = new List<int[]>();
            var width = grid[0].Length + 2;
            var nineRow = new int[width];
            for (var i = 0; i < width; i++)
            {
                nineRow[i] = 9;
            }
            expandedGrid.Add(nineRow);

            foreach (var row in grid)
            {
                var newRow = new int[width];

                newRow[0] = 9;
                newRow[^1] = 9;

                for (var i = 0; i < row.Length; i++)
                {
                    newRow[i + 1] = row[i];
                }

                expandedGrid.Add(newRow);
            }
            
            expandedGrid.Add(nineRow);

            return expandedGrid;
        }

        private List<Tuple<int, int>> DetermineBasin(List<int[]> grid, Tuple<int, int> lowPoint, List<Tuple<int, int>> basin)
        {
            basin.Add(lowPoint);

            var x = lowPoint.Item1;
            var y = lowPoint.Item2;
            var current = grid[y][x];

            // Left
            var checking = grid[y][x - 1];
            if (checking >= current && checking != 9 && basin.Count(i => i.Item1 == x - 1 && i.Item2 == y) == 0)
            {
                basin = DetermineBasin(grid, new Tuple<int, int>(x - 1, y), basin);
            }

            // Right
            checking = grid[y][x + 1];
            if (checking >= current && checking != 9 && basin.Count(i => i.Item1 == x + 1 && i.Item2 == y) == 0)
            {
                basin = DetermineBasin(grid, new Tuple<int, int>(x + 1, y), basin);
            }
            

            // Above
            checking = grid[y - 1][x];
            if (checking >= current && checking != 9 && basin.Count(i => i.Item1 == x && i.Item2 == y - 1) == 0)
            {
                basin = DetermineBasin(grid, new Tuple<int, int>(x, y - 1), basin);
            }

            // Below
            checking = grid[y + 1][x];
            if (checking >= current && checking != 9 && basin.Count(i => i.Item1 == x && i.Item2 == y + 1) == 0)
            {
                basin = DetermineBasin(grid, new Tuple<int, int>(x, y + 1), basin);
            }

            return basin;
        }
    }
}
