using System;
using System.Linq;

namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> VAT = n => n * 1.20M;

            decimal[] prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse).Select(VAT).ToArray();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}