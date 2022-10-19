using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            Dictionary<double, int> countByNumbers = new Dictionary<double, int>();

            foreach (var num in input)
            {
                if (!countByNumbers.ContainsKey(num))
                {
                    countByNumbers.Add(num, 0);
                }

                countByNumbers[num]++;
            }

            foreach (var countByNumber in countByNumbers)
            {
                Console.WriteLine($"{countByNumber.Key} - {countByNumber.Value} times");
            }
        }
    }
}
