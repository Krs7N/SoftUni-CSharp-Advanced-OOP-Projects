using System;

namespace _02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> appender = names =>
            {
                foreach (var name in names)
                {
                    Console.WriteLine($"Sir {name}");
                }
            };

            appender(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}