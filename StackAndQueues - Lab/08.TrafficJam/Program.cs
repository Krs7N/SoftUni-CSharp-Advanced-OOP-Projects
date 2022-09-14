using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsToPassOnGreenLight = int.Parse(Console.ReadLine());
            int carsPassed = 0;

            string command = Console.ReadLine();

            var queue = new Queue<string>();

            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < carsToPassOnGreenLight; i++)
                    {
                        if (queue.Count > 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            carsPassed++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}