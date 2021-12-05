using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day05
{
    class Puzzle1 : IPuzzle
    {
        public Puzzle1()
        {
            Console.WriteLine("\nDay 05 - Puzzle 1");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day05/input.txt");
            var grid = new List<Tuple<int, int>>();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var points = line.Replace(" -> ", ",").Split(",");
                
                var startX = int.Parse(points[0]);
                var startY = int.Parse(points[1]);
                var endX = int.Parse(points[2]);
                var endY = int.Parse(points[3]);

                int start;
                int end;
                if (startX == endX)
                {
                    start = startY;
                    end = endY + 1;
                    if (startY > endY)
                    {
                        start = endY;
                        end = startY + 1;
                    }

                    for (var i = start; i < end; i++)
                    {
                        grid.Add(new Tuple<int, int>(startX, i));
                    }
                } else if (startY == endY)
                {
                    start = startX;
                    end = endX + 1;
                    if (startX > endX)
                    {
                        start = endX;
                        end = startX + 1;
                    }

                    for (var i = start; i < end; i++)
                    {
                        grid.Add(new Tuple<int, int>(i, startY));
                    }
                }
            }

            Console.WriteLine($"Outcome: {grid.GroupBy(x => x).Count(group => group.Count() > 1)}");
        }
    }
}
