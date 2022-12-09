namespace _01.Vehicles.Core
{
    using System;

    using Contracts;
    using IO.Contracts;
    using Models;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] carProperties = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] truckProperties = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Vehicle car = new Car(double.Parse(carProperties[1]), double.Parse(carProperties[2]));
            Vehicle truck = new Truck(double.Parse(truckProperties[1]), double.Parse(truckProperties[2]));

            int numberOfCommands = int.Parse(this.reader.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commands = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (commands[0])
                {
                    case "Drive":
                        if (commands[1] == "Car")
                        {
                            car.Drive(double.Parse(commands[2]));
                        }
                        else
                        {
                            truck.Drive(double.Parse(commands[2]));
                        }
                        break;
                    case "Refuel":
                        if (commands[1] == "Car")
                        {
                            car.Refuel(double.Parse(commands[2]));
                        }
                        else
                        {
                            truck.Refuel(double.Parse(commands[2]));
                        }
                        break;
                }
            }

            this.writer.WriteLine($"Car: {car.FuelQuantity:f2}");
            this.writer.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}