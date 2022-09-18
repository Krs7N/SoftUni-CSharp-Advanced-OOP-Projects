using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantityForDay = int.Parse(Console.ReadLine());
            int[] ordersQuantity = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var queueOrders = new Queue<int>(ordersQuantity);

            Console.WriteLine(queueOrders.Max());

            while (foodQuantityForDay > 0)
            {
                int customer = queueOrders.Peek();

                if (customer <= foodQuantityForDay)
                {
                    foodQuantityForDay -= customer;
                    queueOrders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', queueOrders)}");
                    return;
                }

                if (queueOrders.Count == 0)
                {
                    Console.WriteLine("Orders complete");
                    return;
                }
            }
        }
    }
}
