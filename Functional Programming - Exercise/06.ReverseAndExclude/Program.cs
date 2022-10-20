using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToList();
            int numberToDivideWith = int.Parse(Console.ReadLine());

            Func<List<int>, List<int>> divider = numbers =>
            {
                List<int> result = new List<int>();

                foreach (var number in numbers)
                {
                    if (number % numberToDivideWith != 0)
                    {
                        result.Add(number);
                    }
                }

                return result;
            };

            Console.WriteLine(string.Join(' ', divider(numbers)));
        }
    }
}