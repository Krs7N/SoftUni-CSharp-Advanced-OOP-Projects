using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int countOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfEngines; i++)
            {
                string[] engineData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = CreateEngine(engineData);

                engines.Add(engine);
            }

            int countOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCars; i++)
            {
                string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = engines.Find(e => e.Model == carData[1]);

                Car car = CreateCar(carData, engine);

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        public static Engine CreateEngine(string[] engineData)
        {
            Engine engine = new Engine(engineData[0], int.Parse(engineData[1]));

            if (engineData.Length > 2)
            {
                bool isDigit = int.TryParse(engineData[2], out int displacement);

                if (isDigit)
                {
                    engine.Displacement = displacement;
                }
                else
                {
                    engine.Efficiency = engineData[2];
                }

                if (engineData.Length > 3)
                {
                    engine.Efficiency = engineData[3];
                }
            }

            return engine;
        }

        public static Car CreateCar(string[] carData, Engine engine)
        {
            Car car = new Car(carData[0], engine);

            if (carData.Length > 2)
            {
                bool isDigit = int.TryParse(carData[2], out int weight);

                if (isDigit)
                {
                    car.Weight = weight;
                }
                else
                {
                    car.Color = carData[2];
                }

                if (carData.Length > 3)
                {
                    car.Color = carData[3];
                }
            }

            return car;
        }
    }
}