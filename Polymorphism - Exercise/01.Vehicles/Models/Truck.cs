namespace _01.Vehicles.Models
{
    using System;

    using Contracts;
    using Utilities;

    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumptionPerKm;
        }

        public sealed override double FuelQuantity { get; set; }

        public override double FuelConsumption { get; }

        public override void Drive(double distance)
        {
            if (distance * (FuelConsumption + Constants.TruckAirConditionerFuelConsumption) > FuelQuantity)
            {
                Console.WriteLine("Truck needs refueling");
            }
            else
            {
                FuelQuantity -= distance * (FuelConsumption + Constants.TruckAirConditionerFuelConsumption);
                Console.WriteLine($"Truck travelled {distance} km");
            }
        }

        public override void Refuel(double liters)
        {
            double realFuel = liters * 0.95;

            FuelQuantity += realFuel;
        }
    }
}