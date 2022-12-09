namespace _01.Vehicles.Models
{
    using System;

    using Contracts;
    using Utilities;

    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumptionPerKm;
        }

        public sealed override double FuelQuantity { get; set; }

        public override double FuelConsumption { get; }

        public override void Drive(double distance)
        {
            if (distance * (FuelConsumption + Constants.CarAirConditionerFuelConsumption) > FuelQuantity)
            {
                Console.WriteLine("Car needs refueling");
            }
            else
            {
                FuelQuantity -= distance * (FuelConsumption + Constants.CarAirConditionerFuelConsumption);
                Console.WriteLine($"Car travelled {distance} km");
            }
        }

        public override void Refuel(double liters) => FuelQuantity += liters;
    }
}