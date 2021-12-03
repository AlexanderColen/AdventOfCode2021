using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day03
{
    class Puzzle1 : IPuzzle
    {
        public Puzzle1()
        {
            Console.WriteLine("\nDay 03 - Puzzle 1");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day03/input.txt");
            string line;
            var bits = new Dictionary<int, List<char>>();
            while ((line = sr.ReadLine()) != null)
            {
                var rawBits = line.ToCharArray();

                for (var i = 0; i < rawBits.Length; i++)
                {
                    if (bits.ContainsKey(i))
                    {
                        bits[i].Add(rawBits[i]);
                    } else
                    {
                        bits.Add(i, new List<char>(rawBits[i]));
                    }
                }
            }
            
            var mostCommon = new List<char>();
            var leastCommon = new List<char>();

            foreach (var key in bits.Keys)
            {
                var ones = bits[key].Count(x => x == '1');
                var zeroes = bits[key].Count(x => x == '0');

                if (ones > zeroes)
                {
                    mostCommon.Add('1');
                    leastCommon.Add('0');
                } else
                {
                    mostCommon.Add('0');
                    leastCommon.Add('1');
                }
            }

            var gammaRate =  Convert.ToUInt64(new string(mostCommon.ToArray()), 2);
            var epsilonRate =  Convert.ToUInt64(new string(leastCommon.ToArray()), 2);

            Console.WriteLine($"Outcome: {gammaRate * epsilonRate}");
        }
    }
}
