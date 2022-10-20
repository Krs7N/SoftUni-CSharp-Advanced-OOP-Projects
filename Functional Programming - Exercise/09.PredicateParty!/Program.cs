using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;

namespace _09.PredicateParty_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string command;

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string filter = tokens[1];
                string value = tokens[2];

                if (action == "Remove")
                {
                    names.RemoveAll(GetPredicate(filter, value));
                }
                else
                {
                    List<string> doublePeople = names.FindAll(GetPredicate(filter, value));

                    int index = names.FindIndex(GetPredicate(filter, value));

                    if (index >= 0)
                    {
                        names.InsertRange(index, doublePeople);
                    }
                }
            }

            Console.WriteLine(names.Any()
                ? $"{string.Join(", ", names)} are going to the party!"
                : "Nobody is going to the party!");
        }

        private static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "StartsWith":
                    return p => p.StartsWith(value);
                case "EndsWith":
                    return p => p.EndsWith(value);
                case "Length":
                    return p => p.Length == int.Parse(value);
                default:
                    return default(Predicate<string>);
            }
        }
    }
}
