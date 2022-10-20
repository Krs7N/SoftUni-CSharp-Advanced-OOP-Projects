using System;

namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printer = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            printer(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}