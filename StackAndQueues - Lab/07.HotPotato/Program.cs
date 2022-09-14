using System;
using System.Collections.Generic;
using System.Globalization;

namespace _07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var kids = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int tossesTillRemoved = int.Parse(Console.ReadLine());

            int curTosses = 1;

            var queue = new Queue<string>(kids);

            while (queue.Count > 1)
            {
                string curKid = queue.Dequeue();
                if (curTosses == tossesTillRemoved)
                {
                    Console.WriteLine($"Removed {curKid}");
                    curTosses = 1;
                }
                else
                {
                    queue.Enqueue(curKid);
                    curTosses++;
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}