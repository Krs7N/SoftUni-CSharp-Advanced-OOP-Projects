using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] caffeine = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] energyDrink = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> caffeines = new Stack<int>(caffeine);
            Queue<int> energyDrinks = new Queue<int>(energyDrink);

            int stamatCaffeine = 0;

            while (caffeines.Count > 0 && energyDrinks.Count > 0)
            {
                int firstCaffeine = caffeines.Pop();
                int firstDrink = energyDrinks.Dequeue();

                if (stamatCaffeine == 0 && firstDrink * firstCaffeine <= 300)
                {
                    stamatCaffeine += firstDrink * firstCaffeine;
                }
                else if (firstDrink * firstCaffeine <= 300 - stamatCaffeine)
                {
                    stamatCaffeine += firstDrink * firstCaffeine;
                }
                else
                {
                    energyDrinks.Enqueue(firstDrink);

                    if (stamatCaffeine - 30 < 0)
                    {
                        stamatCaffeine = 0;
                    }
                    else
                    {
                        stamatCaffeine -= 30;
                    }
                }
            }

            Console.WriteLine(energyDrinks.Any()
                ? $"Drinks left: {string.Join(", ", energyDrinks)}"
                : "At least Stamat wasn't exceeding the maximum caffeine.");

            Console.WriteLine($"Stamat is going to sleep with {stamatCaffeine} mg caffeine.");
        }
    }
}