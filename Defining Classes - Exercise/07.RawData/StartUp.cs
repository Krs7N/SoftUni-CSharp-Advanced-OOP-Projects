using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int countOfCarsToAdd = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < countOfCarsToAdd; i++)
            {
                string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(carData[0], int.Parse(carData[1]), int.Parse(carData[2]), int.Parse(carData[3]),
                    carData[4], double.Parse(carData[5]), int.Parse(carData[6]), double.Parse(carData[7]), int.Parse(carData[8]), double.Parse(carData[9]), int.Parse(carData[10]), double.Parse(carData[11]), int.Parse(carData[12]));

                cars.Add(car);
            }

            string typeOfCargo = Console.ReadLine();
            string[] filteredCars;

            if (typeOfCargo == "fragile")
            {
                filteredCars = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1)).Select(c => c.Model).ToArray();
            }
            else
            {
                filteredCars = cars.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250).Select(c => c.Model)
                    .ToArray();
            }

            foreach (var filteredCar in filteredCars)
            {
                Console.WriteLine(filteredCar);
            }
        }
    }
}