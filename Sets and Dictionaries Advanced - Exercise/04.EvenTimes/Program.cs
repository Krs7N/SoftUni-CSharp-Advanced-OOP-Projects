using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repeatedNumbers = new Dictionary<int, int>();

            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!repeatedNumbers.ContainsKey(number))
                {
                    repeatedNumbers.Add(number, 0);
                }

                repeatedNumbers[number]++;
            }

            repeatedNumbers = repeatedNumbers.Where(n => n.Value % 2 == 0).ToDictionary(n => n.Key, n => n.Value);

            Console.WriteLine(string.Join(Environment.NewLine, repeatedNumbers.Keys));
        }
    }
}