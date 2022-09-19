using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] filledBottles = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var cups = new Queue<int>(cupsCapacity);
            var bottles = new Stack<int>(filledBottles);

            int wastedLiters = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int curCup = cups.Peek();
                int curBottle = bottles.Peek();

                if (curBottle >= curCup)
                {
                    if (curCup - curBottle <= 0)
                    {
                        wastedLiters += Math.Abs(curCup - curBottle);
                        cups.Dequeue();
                        bottles.Pop();
                    }
                }
                else
                {
                    while (curCup > 0)
                    {
                        curCup -= bottles.Pop();

                        if (curCup <= 0)
                        {
                            wastedLiters += Math.Abs(curCup);
                            cups.Dequeue();
                        }
                    }
                }
            }

            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
            }
            else if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(' ', cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLiters}");
        }
    }
}
