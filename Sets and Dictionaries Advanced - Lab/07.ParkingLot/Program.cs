using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> cars = new HashSet<string>();

            while (carTokens[0] != "END")
            {
                string command = carTokens[0];
                string plateNumber = carTokens[1];

                if (command == "IN")
                {
                    cars.Add(plateNumber);
                }
                else
                {
                    cars.Remove(plateNumber);
                }

                carTokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (!cars.Any())
            {
                Console.WriteLine("Parking Lot is Empty");

                return;
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}