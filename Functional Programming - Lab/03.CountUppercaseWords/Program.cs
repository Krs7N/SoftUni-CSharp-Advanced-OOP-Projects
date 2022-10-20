using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Func<string, bool> startsWithUppercase = w => char.IsUpper(w[0]);

            //string[] sentence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .Where(startsWithUppercase).ToArray();

            //foreach (var word in sentence)
            //{
            //    Console.WriteLine(word);
            //}

            Predicate<string> startsWithUppercase = w => char.IsUpper(w[0]);

            Console.WriteLine(string.Join(Environment.NewLine, Array.FindAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), startsWithUppercase)));
        }
    }
}