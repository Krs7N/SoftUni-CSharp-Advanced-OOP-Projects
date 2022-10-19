using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var chemicalElements = new SortedSet<string>();

            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                string[] chemicalElement = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var c in chemicalElement)
                {
                    chemicalElements.Add(c);
                }
            }

            Console.WriteLine(string.Join(' ', chemicalElements));
        }
    }
}
