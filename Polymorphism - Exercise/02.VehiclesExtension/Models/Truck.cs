namespace _02.VehiclesExtension.Models
{
    using System;

    using Contracts;
    using Utilities;
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }
            this.FuelConsumption = fuelConsumptionPerKm;
            this.TankCapacity = tankCapacity;
        }

        public sealed override double FuelQuantity { get; set; }

        public override double FuelConsumption { get; }

        public override double TankCapacity { get; }

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
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            if (liters + FuelQuantity > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                return;
            }

            double realFuel = liters * 0.95;

            FuelQuantity += realFuel;
        }
    }
}