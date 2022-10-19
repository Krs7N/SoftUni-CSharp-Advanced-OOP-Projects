using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] setLengths = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var firstSet = new HashSet<int>(setLengths[0]);
            var secondSet = new HashSet<int>(setLengths[1]);

            for (int i = 0; i < setLengths[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < setLengths[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(' ', firstSet));
        }
    }
}