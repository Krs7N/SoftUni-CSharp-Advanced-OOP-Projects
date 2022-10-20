using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Predicate<int>> predicates = new List<Predicate<int>>();

            int endOfRange = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] numbers = Enumerable.Range(1, endOfRange).ToArray();

            foreach (var divider in dividers)
            {
                predicates.Add(n => n % divider == 0);
            }

            List<int> result = new List<int>();

            foreach (var number in numbers)
            {
                bool isDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    result.Add(number);
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}