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
                    var day = i.ToString().PadLeft(2, '0');
                    var dayNamespace = $"AdventOfCode2021.Day{day}";

                    try
                    {
                        Activator.CreateInstance(Type.GetType(dayNamespace + ".Puzzle1"));

                        if (i != 25)
                        {
                            Activator.CreateInstance(Type.GetType(dayNamespace + ".Puzzle2"));
                        }
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine($"\nDay {day} has not yet been (fully) implemented.");
                    }
                }
            } else if (args.Length == 1)
            {
                var dayNamespace = $"AdventOfCode2021.Day{args[0].PadLeft(2, '0')}";
                try
                {
                    Activator.CreateInstance(Type.GetType(dayNamespace + ".Puzzle1"));

                    if (args[0] != "25")
                    {
                        Activator.CreateInstance(Type.GetType(dayNamespace + ".Puzzle2"));
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine($"\nDay {args[0]} does not exist.");
                }
            } else if (args.Length == 2)
            {
                var day = args[0].PadLeft(2, '0');
                var dayNamespace = $"AdventOfCode2021.Day{day}";
                try
                {
                    Activator.CreateInstance(Type.GetType($"{dayNamespace}.Puzzle{args[1]}"));
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine($"\nDay {day} Puzzle {args[1]} does not exist.");
                }
            }
        }
    }
}
