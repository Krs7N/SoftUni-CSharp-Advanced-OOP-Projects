namespace _02.VehiclesExtension.Core
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
            string[] busProperties = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Vehicle car = new Car(double.Parse(carProperties[1]), double.Parse(carProperties[2]), double.Parse(carProperties[3]));
            Vehicle truck = new Truck(double.Parse(truckProperties[1]), double.Parse(truckProperties[2]), double.Parse(truckProperties[3]));
            Bus bus = new Bus(double.Parse(busProperties[1]), double.Parse(busProperties[2]),
                double.Parse(busProperties[3]));

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
                        else if (commands[1] == "Truck")
                        {
                            truck.Drive(double.Parse(commands[2]));
                        }
                        else
                        {
                            bus.Drive(double.Parse(commands[2]));
                        }
                        break;
                    case "Refuel":
                        if (commands[1] == "Car")
                        {
                            car.Refuel(double.Parse(commands[2]));
                        }
                        else if (commands[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(commands[2]));
                        }
                        else
                        {
                            bus.Refuel(double.Parse(commands[2]));
                        }
                        break;
                    case "DriveEmpty":
                        bus.DriveEmpty(double.Parse(commands[2]));
                        break;
                }
            }

            this.writer.WriteLine($"Car: {car.FuelQuantity:f2}");
            this.writer.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            this.writer.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}