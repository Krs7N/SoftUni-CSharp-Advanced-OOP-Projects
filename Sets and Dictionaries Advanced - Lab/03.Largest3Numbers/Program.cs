using System;
using System.Linq;

namespace _03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(' ', Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(n => n)
                .Take(3)
                .ToList()));
        }
    }
}