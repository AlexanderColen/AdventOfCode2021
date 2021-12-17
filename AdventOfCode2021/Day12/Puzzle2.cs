using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day12
{
    class Puzzle2 : IPuzzle
    {
        public Puzzle2()
        {
            Console.WriteLine("\nDay 12 - Puzzle 2");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day12/input.txt");
            var caveSystem = new List<Cave>();
            Cave startCave = null;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var caves = line.Split('-');

                var cave1 = caveSystem.Find(x => x.Name == caves[0]);
                var cave2 = caveSystem.Find(x => x.Name == caves[1]);

                if (cave1 == null)
                {
                    cave1 = new Cave(caves[0], caves[0].Any(c => char.IsUpper(c)));
                    caveSystem.Add(cave1);

                    if (cave1.Name == "start")
                    {
                        startCave = cave1;
                    }
                }

                if (cave2 == null)
                {
                    cave2 = new Cave(caves[1], caves[1].Any(c => char.IsUpper(c)));
                    caveSystem.Add(cave2);

                    if (cave2.Name == "start")
                    {
                        startCave = cave2;
                    }
                }

                if (!cave1.Connections.Contains(cave2))
                {
                    cave1.Connections.Add(cave2);
                }

                if (!cave2.Connections.Contains(cave1))
                {
                    cave2.Connections.Add(cave1);
                }
            }

            var paths = TraverseCaves(startCave, new List<Cave>() { startCave }, new List<string>());

           Console.WriteLine($"Outcome: {paths.Count}");
        }

        private List<string> TraverseCaves(Cave current, List<Cave> traversed, List<string> paths)
        {
            if (current.Name == "end") {
                var combinedPath = string.Join(',', traversed.Select(x => x.Name));
                if (!paths.Contains(combinedPath))
                {
                    paths.Add(combinedPath);
                }
                return paths;
            }

            foreach (var cave in current.Connections)
            {
                if (!traversed[^1].Connections.Contains(cave) || cave.Name == "start")
                {
                    continue;
                }

                var smallVisitedCaves = traversed.Where(x => x.Name != "start" && x.Name != "end" && !x.IsLarge);
                var canVisitTwice = smallVisitedCaves.GroupBy(x => x.Name).Count(x => x.Count() == 2) == 0;
                var visitedCount = traversed.Count(x => x.Name == cave.Name);

                if (cave.IsLarge || visitedCount == 0 || (visitedCount == 1 && canVisitTwice))
                {
                    var newTraversed = new List<Cave>(traversed) { cave };
                    paths = TraverseCaves(cave, newTraversed, paths);
                }
            }

            return paths;
        }
    }
}
