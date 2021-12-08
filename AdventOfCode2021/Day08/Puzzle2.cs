using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day08
{
    class Puzzle2 : IPuzzle
    {
        public Puzzle2()
        {
            Console.WriteLine("\nDay 08 - Puzzle 2");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day08/input.txt");
            var signalPatterns = new List<string[]>();
            var outputValues = new List<string[]>();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var split = line.Split(" | ");

                signalPatterns.Add(split[0].Split(' '));
                outputValues.Add(split[1].Split(' '));
            }

            long total = 0;

            for (var i = 0; i < signalPatterns.Count(); i++)
            {
                var unknownPatterns = signalPatterns[i];
                var numberKnowledge = new string[10];
                var charKnowledge = new string[7];
                // Sort the patterns by length the first time to get the free knowledge.
                Array.Sort(unknownPatterns, (x,y) => x.Length < y.Length ? -1 : 1);

                // First three will be 1, 7 & 4 in that order.
                numberKnowledge[1] = unknownPatterns[0];
                numberKnowledge[7] = unknownPatterns[1];
                numberKnowledge[4] = unknownPatterns[2];
                // Last one will be 8.
                numberKnowledge[8] = unknownPatterns[^1];

                // Update the array.
                unknownPatterns = unknownPatterns.Where(x => !numberKnowledge.Contains(x)).ToArray();

                // Determine the top char.
                charKnowledge[0] = numberKnowledge[7].Where(x => !numberKnowledge[1].Contains(x)).First().ToString();

                var segmentParts = GainKnowledge(unknownPatterns, numberKnowledge, charKnowledge);
                var rawSolution = "";
                foreach (var output in outputValues[i])
                {
                    for (var j = 0; j < segmentParts.Length; j++)
                    {
                        if (output.Length == segmentParts[j].Length && output.All(x => segmentParts[j].Contains(x)))
                        {
                            rawSolution += j;
                            break;
                        }
                    }
                }

                total += int.Parse(rawSolution);
            }

            Console.WriteLine($"Outcome: {total}");
        }

        private string[] GainKnowledge(string[] unknownPatterns, string[] numberKnowledge, string[] charKnowledge)
        {
            if (unknownPatterns.Length == 0)
            {
                return numberKnowledge;
            }

            var solvedPatterns = new List<string>();

            foreach (var pattern in unknownPatterns)
            {
                switch (pattern.Length)
                {
                    // 5 segments can be a 2, 3 or 5.
                    case 5:
                        // The 3 contains both parts of the 1.
                        if (!KnowsParts(numberKnowledge, new int[] { 3 }))
                        {
                            if (numberKnowledge[1].All(x => pattern.Contains(x)))
                            {
                                numberKnowledge[3] = pattern;
                                solvedPatterns.Add(pattern);
                            }
                        }
                        // The 2 is leftover when knowing 3 & 5.
                        else if (!KnowsParts(numberKnowledge, new int[] { 2 }) && KnowsParts(numberKnowledge, new int[] { 3, 5 }))
                        {
                            numberKnowledge[2] = pattern;
                            solvedPatterns.Add(pattern);
                        }
                        continue;

                    // 6 segments can be a 0, 6 or 9.
                    case 6:
                        // A 9 can be figured out by knowing 4 and the top char.
                        if (!KnowsParts(numberKnowledge, new int[] { 9 }) && KnowsParts(numberKnowledge, new int[]{ 4 }) && KnowsParts(charKnowledge, new int[] { 0 }))
                        {
                            if (numberKnowledge[4].Concat(charKnowledge[0]).All(x => pattern.Contains(x)))
                            {
                                numberKnowledge[9] = pattern;
                                solvedPatterns.Add(pattern);
                                // The bottom left char is the one that 9 is missing compared to the 8.
                                charKnowledge[4] = numberKnowledge[8].Where(x => !numberKnowledge[9].Contains(x)).First().ToString();
                            }
                        }
                        // A 0 can be figured out by knowing 6 and 9, since it's the leftover pattern.
                        else if (!KnowsParts(numberKnowledge, new int [] { 0 }) && KnowsParts(numberKnowledge, new int[] { 6, 9 }))
                        {
                            numberKnowledge[0] = pattern;
                            solvedPatterns.Add(pattern);
                        }
                        continue;

                    default:
                        Console.WriteLine("How did you get here?");
                        break;
                }
            }

            // We can figure out 5 and 6 if we know the bottom left char.
            if (!KnowsParts(numberKnowledge, new int[] { 5, 6}) && KnowsParts(charKnowledge, new int[] { 4 }))
            {
                foreach (var five in unknownPatterns.Where(x => x.Length == 5))
                {
                    foreach (var six in unknownPatterns.Where(x => x.Length == 6 && x.Contains(charKnowledge[4])))
                    {
                        if (five.All(x => six.Where(y => y.ToString() != charKnowledge[4]).Contains(x)))
                        {
                            numberKnowledge[5] = five;
                            numberKnowledge[6] = six;
                            solvedPatterns.Add(five);
                            solvedPatterns.Add(six);
                            break;
                        }
                    }
                }
            }

            return GainKnowledge(unknownPatterns.Where(x => !solvedPatterns.Contains(x)).ToArray(), numberKnowledge, charKnowledge);
        }

        private bool KnowsParts(string[] parts, int[] required)
        {
            return required.All(x => parts[x] != null);
        }
    }
}
