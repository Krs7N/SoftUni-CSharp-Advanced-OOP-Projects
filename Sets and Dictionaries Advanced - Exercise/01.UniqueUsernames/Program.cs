using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var usernames = new HashSet<string>();

            int usernameCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < usernameCount; i++)
            {
                string username = Console.ReadLine();

                usernames.Add(username);
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}