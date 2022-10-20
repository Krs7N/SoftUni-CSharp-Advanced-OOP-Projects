using System;
using System.Linq;

namespace _02.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = int.Parse;

            int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(parser).ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}