using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Func<List<int>, List<int>> add = numbers =>
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i]++;
                }

                return numbers;
            };

            Func<List<int>, List<int>> subtract = numbers =>
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i]--;
                }

                return numbers;
            };

            Func<List<int>, List<int>> multiply = numbers =>
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i] *= 2;
                }

                return numbers;
            };

            Action<List<int>> print = names => Console.WriteLine(string.Join(' ', names));

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        add(numbers);
                        break;
                    case "multiply":
                        multiply(numbers);
                        break;
                    case "subtract":
                        subtract(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
            }
        }
    }
}