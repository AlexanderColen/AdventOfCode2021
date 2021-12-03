using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day03
{
    class Puzzle2 : IPuzzle
    {
        public Puzzle2()
        {
            Console.WriteLine("\nDay 03 - Puzzle 2");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day03/input.txt");
            string line;
            var binaryNumbers = new List<string>();
            while ((line = sr.ReadLine()) != null)
            {
                binaryNumbers.Add(line);
            }
            
            var mostCommonCriteria = "";
            var leastCommonCriteria = "";
            var leftoverMost = binaryNumbers;
            var leftoverLeast = binaryNumbers;
            for (var i = 0; i < binaryNumbers[0].Length; i++)
            {
                if (leftoverMost.Count() > 1)
                {
                    mostCommonCriteria += DetermineMostCommonBit(leftoverMost, i, true);
                    leftoverMost = leftoverMost.Where(x => x.StartsWith(mostCommonCriteria)).ToList();
                }

                if (leftoverLeast.Count() > 1)
                {
                    leastCommonCriteria += DetermineMostCommonBit(leftoverLeast, i, false);
                    leftoverLeast = leftoverLeast.Where(x => x.StartsWith(leastCommonCriteria)).ToList();
                }

                if (leftoverMost.Count() == 1 && leftoverLeast.Count() == 1)
                {
                    break;
                }
            }
            
            var oxygenRate = Convert.ToUInt64(leftoverMost[0], 2);
            var scrubberRate = Convert.ToUInt64(leftoverLeast[0], 2);

            Console.WriteLine($"Outcome: {oxygenRate * scrubberRate}");
        }

        private char DetermineMostCommonBit(List<string> bits, int position, bool mostCommon)
        {
            var onesCount = bits.Count(x => x[position] == '1');
            var zeroesCount = bits.Count(x => x[position] == '0');

            if (mostCommon)
            {
                return zeroesCount > onesCount ? '0' : '1';
            } else
            {
                return onesCount < zeroesCount ? '1' : '0';
            }
        }
    }
}
