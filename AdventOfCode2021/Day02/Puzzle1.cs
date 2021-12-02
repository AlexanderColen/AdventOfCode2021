using AdventOfCode2021.Base;
using System;
using System.IO;

namespace AdventOfCode2021.Day02
{
    class Puzzle1 : IPuzzle
    {
        public Puzzle1()
        {
            Console.WriteLine("\nDay 02 - Puzzle 1");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day02/input.txt");
            int x = 0;
            int y = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var instructions = line.Split(' ');

                switch (instructions[0])
                {
                    case "forward":
                        x += int.Parse(instructions[1]);
                        break;

                    case "up":
                        y -= int.Parse(instructions[1]);
                        break;

                    case "down":
                        y += int.Parse(instructions[1]);
                        break;
                }
            }

            Console.WriteLine($"Outcome: {x * y}");
        }
    }
}
