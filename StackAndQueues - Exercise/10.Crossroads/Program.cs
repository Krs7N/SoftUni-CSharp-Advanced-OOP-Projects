using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightDurationSeconds = int.Parse(Console.ReadLine());
            int freeWindowDurationSeconds = int.Parse(Console.ReadLine());

            var queue = new Queue<string>();

            string command = Console.ReadLine();

            int passedCars = 0;

            while (command != "END")
            {
                if (command == "green")
                {
                    int greenLightCopy = greenLightDurationSeconds;
                    int freeWindowCopy = freeWindowDurationSeconds;

                    while (greenLightCopy > 0)
                    {
                        if (queue.Count == 0)
                        {
                            break;
                        }

                        string car = queue.Peek();

                        for (int i = 0; i < car.Length; i++)
                        {
                            if (greenLightCopy == 0 && freeWindowCopy == 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {car[i]}.");
                                return;
                            }

                            if (greenLightCopy == 0)
                            {
                                freeWindowCopy--;
                            }
                            else
                            {
                                greenLightCopy--;
                            }

                            if (i == car.Length - 1)
                            {
                                passedCars++;
                                queue.Dequeue();
                            }
                        }
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}