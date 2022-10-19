using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repeatedByChars = new SortedDictionary<char, int>();

            string sentence = Console.ReadLine();

            for (int i = 0; i < sentence.Length; i++)
            {
                if (!repeatedByChars.ContainsKey(sentence[i]))
                {
                    repeatedByChars.Add(sentence[i], 0);
                }

                repeatedByChars[sentence[i]]++;
            }

            foreach (var repeatedByChar in repeatedByChars)
            {
                Console.WriteLine($"{repeatedByChar.Key}: {repeatedByChar.Value} time/s");
            }
        }
    }
}