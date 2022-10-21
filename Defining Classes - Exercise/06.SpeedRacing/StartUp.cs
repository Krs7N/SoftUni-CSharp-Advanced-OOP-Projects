using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int carsToAdd = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsToAdd; i++)
            {
                string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(carData[0], double.Parse(carData[1]), double.Parse(carData[2]));

                cars.Add(car);
            }

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "End")
            {
                string carModel = commands[1];
                double distanceTraveled = double.Parse(commands[2]);

                Car curCar = cars.FirstOrDefault(c => c.Model == carModel);

                curCar.Drive(distanceTraveled);

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }
}