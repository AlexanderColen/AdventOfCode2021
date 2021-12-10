using AdventOfCode2021.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2021.Day10
{
    class Puzzle1 : IPuzzle
    {
        public Puzzle1()
        {
            Console.WriteLine("\nDay 10 - Puzzle 1");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day10/input.txt");
            var openingChars = new char[4] { '(', '[', '{', '<' };
            var closingChars = new char[4] { ')', ']', '}', '>' };
            var illegalChars = new List<char>();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var openChunks = new List<char>();
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
                            illegalChars.Add(c);
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"Outcome: {illegalChars.Count(x => x == ')') * 3 + illegalChars.Count(x => x == ']') * 57 + illegalChars.Count(x => x == '}') * 1197 + illegalChars.Count(x => x == '>') * 25137}");
        }
    }
}
