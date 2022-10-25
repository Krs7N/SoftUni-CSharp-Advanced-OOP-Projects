using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tiresList = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string commands = Console.ReadLine();

            while (commands != "No more tires")
            {
                string[] tiresInfo = commands.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Tire[] tires = new Tire[4]
                {
                    new Tire(int.Parse(tiresInfo[0]), double.Parse(tiresInfo[1])),
                    new Tire(int.Parse(tiresInfo[2]), double.Parse(tiresInfo[3])),
                    new Tire(int.Parse(tiresInfo[4]), double.Parse(tiresInfo[5])),
                    new Tire(int.Parse(tiresInfo[6]), double.Parse(tiresInfo[7]))
                };

                tiresList.Add(tires);

                commands = Console.ReadLine();
            }

            commands = Console.ReadLine();

            while (commands != "Engines done")
            {
                string[] enginesInfo = commands.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine(int.Parse(enginesInfo[0]), double.Parse(enginesInfo[1]));

                engines.Add(engine);

                commands = Console.ReadLine();
            }

            commands = Console.ReadLine();

            while (commands != "Show special")
            {
                string[] carsInfo = commands.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(carsInfo[0], carsInfo[1], int.Parse(carsInfo[2]), double.Parse(carsInfo[3]), double.Parse(carsInfo[4]), engines[int.Parse(carsInfo[5])], tiresList[int.Parse(carsInfo[6])]);

                cars.Add(car);

                commands = Console.ReadLine();
            }

            var specialCars = cars.Where(c =>
                c.Year >= 2017 && c.Engine.HorsePower > 330 && c.Tires.Sum(t => t.Pressure) >= 9 &&
                c.Tires.Sum(t => t.Pressure) <= 10).ToList();

            foreach (var specialCar in specialCars)
            {
                specialCar.FuelQuantity = specialCar.Drive20Kms(specialCar.FuelQuantity, specialCar.FuelConsumption);
                Console.WriteLine(specialCar.Print());
            }
        }
    }
}