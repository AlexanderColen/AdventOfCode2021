using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day10
{
    class Puzzle2 : IPuzzle
    {
        public Puzzle2()
        {
            Console.WriteLine("\nDay 10 - Puzzle 2");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day10/input.txt");
            var openingChars = new char[4] { '(', '[', '{', '<' };
            var closingChars = new char[4] { ')', ']', '}', '>' };
            var incompleteChunkChars = new List<List<char>>();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var openChunks = new List<char>();
                var corrupted = false;
                foreach (var c in line)
                {
                    if (openingChars.Contains(c))
                    {
                        openChunks.Add(c);
                    } else if (closingChars.Contains(c))
                    {
                        if (Array.FindIndex(closingChars, x => x == c) == Array.FindIndex(openingChars, x => x == openChunks[^1]))
                        {
                            openChunks = openChunks.SkipLast(1).ToList();
                        } else
                        {
                            corrupted = true;
                            break;
                        }
                    }
                }

                if (!corrupted)
                {
                    incompleteChunkChars.Add(openChunks);
                }
            }

            var scores = new List<long>();
            
            foreach (var chunk in incompleteChunkChars)
            {
                long score = 0;

                chunk.Reverse();

                foreach (var c in chunk)
                {
                    var closingChar = closingChars[Array.FindIndex(openingChars, x => x == c)];
                    score *= 5;

                    switch (closingChar)
                    {
                        case ')':
                            score += 1;
                            break;
                        case ']':
                            score += 2;
                            break;
                        case '}':
                            score += 3;
                            break;
                        case '>':
                            score += 4;
                            break;
                    }
                }

                scores.Add(score);
            }
            scores.Sort();

            Console.WriteLine($"Outcome: {scores[scores.Count / 2]}");
        }
    }
}
