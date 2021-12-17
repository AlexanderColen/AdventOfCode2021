using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day13
{
    class Puzzle1 : IPuzzle
    {
        public Puzzle1()
        {
            Console.WriteLine("\nDay 13 - Puzzle 1");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day13/input.txt");
            var initialDots = new List<Tuple<int, int>>();
            var foldInstructions = new List<bool>();
            var maxX = 0;
            var maxY = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains(','))
                {
                    var xy = line.Split(',');
                    initialDots.Add(new Tuple<int, int>(int.Parse(xy[0]), int.Parse(xy[1])));
                }
                else if (line.Contains('='))
                {
                    foldInstructions.Add(line.Contains('y'));
                    var foldLine = int.Parse(line.Split('=')[1]);
                    var newMax = foldLine * 2 + 1;
                    if (line.Contains('x') && newMax > maxX)
                    {
                        maxX = newMax;
                    }
                    else if (line.Contains('y') && newMax > maxY)
                    {
                        maxY = newMax;
                    }
                }
            }

            var grid = GenerateGrid(initialDots, maxX, maxY);

            if (foldInstructions[0])
            {
                grid = FoldUp(grid);
            } else
            {
                grid = FoldLeft(grid);
            }

            var totalDots = 0;
            foreach (var row in grid)
            {
                totalDots += row.Count(x => x == '#');
            }

            Console.WriteLine($"Outcome: {totalDots}");
        }

        private List<char[]> GenerateGrid(List<Tuple<int, int>> dots, int width, int height)
        {
            var grid = new List<char[]>();

            for (var y = 0; y < height; y++)
            {
                var row = new char[width];
                for (var x = 0; x < width; x++)
                {
                    row[x] = '.';
                }

                grid.Add(row);
            }

            foreach (var dot in dots)
            {
                grid[dot.Item2][dot.Item1] = '#';
            }

            return grid;
        }

        private List<char[]> FoldUp(List<char[]> originalGrid)
        {
            var newRowCount = originalGrid.Count / 2 + 1;
            var topHalf = new List<char[]>(originalGrid.SkipLast(newRowCount));
            var bottomHalf = new List<char[]>(originalGrid.Skip(newRowCount));
            bottomHalf.Reverse();

            for (var y = 0; y < newRowCount - 1; y++)
            {
                for (var x = 0; x < originalGrid[0].Length; x++)
                {
                    if (bottomHalf[y][x] == '#')
                    {
                        topHalf[y][x] = '#';
                    }
                }
            }

            return topHalf;
        }

        private List<char[]> FoldLeft(List<char[]> originalGrid)
        {
            var newColumnCount = originalGrid[0].Length / 2 + 1;
            var leftHalf = new List<char[]>( originalGrid.Select(x => x.SkipLast(newColumnCount).ToArray()).ToList());
            var rightHalf = new List<char[]>( originalGrid.Select(x => x.Skip(newColumnCount).ToArray()).ToList());

            foreach (var row in rightHalf)
            {
                Array.Reverse(row);
            }
            
            for (var y = 0; y < leftHalf.Count; y++)
            {
                for (var x = 0; x < newColumnCount - 1; x++)
                {
                    if (rightHalf[y][x] == '#')
                    {
                        leftHalf[y][x] = '#';
                    }
                }
            }

            return leftHalf;
        }
    }
}
