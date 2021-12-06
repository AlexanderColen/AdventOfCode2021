using AdventOfCode2021.Base;
using System;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                for (var i = 1; i < 26; i++)
                {
                    var dayNamespace = $"AdventOfCode2021.Day{i.ToString().PadLeft(2, '0')}";
                    try
                    {
                        Activator.CreateInstance(Type.GetType(dayNamespace + ".Puzzle1"));
                        Activator.CreateInstance(Type.GetType(dayNamespace + ".Puzzle2"));
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine($"\nDay {i} has not yet been implemented.");
                    }
                }
            } else if (args.Length == 1)
            {
                var dayNamespace = $"AdventOfCode2021.Day{args[0].PadLeft(2, '0')}";
                try
                {
                    Activator.CreateInstance(Type.GetType(dayNamespace + ".Puzzle1"));
                    Activator.CreateInstance(Type.GetType(dayNamespace + ".Puzzle2"));
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine($"\nDay {args[0]} does not exist.");
                }
            }
        }
    }
}
