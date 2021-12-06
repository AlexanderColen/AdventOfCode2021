using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day06
{
    class Puzzle2 : IPuzzle
    {
        public Puzzle2()
        {
            Console.WriteLine("\nDay 06 - Puzzle 2");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day06/input.txt");
            var school = new long[9];
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                foreach (var rawFish in line.Split(','))
                {
                    var fish = int.Parse(rawFish);
                    school[fish]++;
                }
            }

            
            for (var days = 0; days < 256; days++)
            {
                var zeroes = school[0];
                Array.Copy(school, 1, school, 0, school.Length - 1);
                school[8] = zeroes;
                school[6] += zeroes;
            }

            Console.WriteLine($"Outcome: {school.Sum()}");
        }
    }
}
