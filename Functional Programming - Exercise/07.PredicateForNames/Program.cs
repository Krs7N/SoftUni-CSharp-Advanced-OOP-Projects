using System;
using System.Text;

namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int requiredLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string[], string> lengthCheck = names =>
            {
                StringBuilder sb = new StringBuilder();

                foreach (var name in names)
                {
                    if (name.Length <= requiredLength)
                    {
                        sb.AppendLine(name);
                    }
                }

                return sb.ToString().Trim();
            };

            Console.WriteLine(lengthCheck(names));
        }
    }
}