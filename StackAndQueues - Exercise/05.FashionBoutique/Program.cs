using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInBox = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());

            var stack = new Stack<int>(clothesInBox);

            int sum = 0;
            int racks = 1;

            while (stack.Count > 0)
            {
                sum += stack.Peek();

                if (sum <= rackCapacity)
                {
                    stack.Pop();
                }
                else
                {
                    racks++;
                    sum = 0;
                }
            }

            Console.WriteLine(racks);
        }
    }
}