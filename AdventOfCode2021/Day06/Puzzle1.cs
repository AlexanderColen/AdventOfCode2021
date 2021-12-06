using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day06
{
    class Puzzle1 : IPuzzle
    {
        public Puzzle1()
        {
            Console.WriteLine("\nDay 06 - Puzzle 1");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day06/input.txt");
            var school = new List<int>();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                foreach (var fish in line.Split(','))
                {
                    school.Add(int.Parse(fish));
                }
            }

            
            for (var days = 0; days < 80; days++)
            {
                var spawns = new List<int>();

                for (var i = 0; i < school.Count; i++)
                {
                    if (school[i] == 0)
                    {
                        spawns.Add(8);
                        school[i] = 6;
                    } else
                    {
                        school[i]--;
                    }
                }

                school = school.Concat(spawns).ToList();
            }

            Console.WriteLine($"Outcome: {school.Count}");
        }
    }
}
