using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day14
{
    class Puzzle1 : IPuzzle
    {
        public Puzzle1()
        {
            Console.WriteLine("\nDay 14 - Puzzle 1");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day14/input.txt");
            string line;
            var polymer = "";
            var rules = new List<Tuple<string, string>>();
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Length == 0)
                {
                    continue;
                }

                if (line.Contains(" -> "))
                {
                    var parts = line.Split(" -> ");
                    rules.Add(new Tuple<string, string>(parts[0], parts[1]));
                } else
                {
                    polymer = line;
                }
            }

            for (var i = 0; i < 10; i++)
            {
                var newPolymer = polymer;
                var offset = 0;
                for (var p = 0; p < polymer.Length - 1; p++)
                {
                    var rule = rules.Find(x => x.Item1 == polymer.Substring(p, 2));
                    if (rule != null)
                    {
                        newPolymer = newPolymer.Insert(p + 1 + offset, rule.Item2);
                        offset++;
                    }
                }
                polymer = newPolymer;
            }
            
            var mostCommon = polymer.GroupBy(x => x).Select(x => x.Count()).Max();
            var leastCommon = polymer.GroupBy(x => x).Select(x => x.Count()).Min();

            Console.WriteLine($"Outcome: {mostCommon - leastCommon}");
        }
    }
}
