using AdventOfCode2021.Base;
using System;
using System.IO;

namespace AdventOfCode2021.Day02
{
    class Puzzle2 : IPuzzle
    {
        public Puzzle2()
        {
            Console.WriteLine("\nDay 02 - Puzzle 2");
            RunPuzzle();
        }

        public void RunPuzzle()
        {
            using StreamReader sr = new StreamReader(@"Day02/input.txt");
            int x = 0;
            int y = 0;
            int aim = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var instructions = line.Split(' ');

                switch (instructions[0])
                {
                    case "forward":
                        x += int.Parse(instructions[1]);
                        y += aim * int.Parse(instructions[1]);
                        break;

                    case "up":
                        aim -= int.Parse(instructions[1]);
                        break;

                    case "down":
                        aim += int.Parse(instructions[1]);
                        break;
                }
            }

            Console.WriteLine($"Outcome: {x * y}");
        }
    }
}
