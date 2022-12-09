namespace _02.VehiclesExtension.Models
{
    using System;

    using Contracts;
    using Utilities;

    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
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
            if (distance * (FuelConsumption + Constants.BusAirConditionerFuelConsumption) > FuelQuantity)
            {
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                FuelQuantity -= distance * (FuelConsumption + Constants.BusAirConditionerFuelConsumption);
                Console.WriteLine($"Bus travelled {distance} km");
            }
        }

        public void DriveEmpty(double distance)
        {
            if (distance * FuelConsumption > FuelQuantity)
            {
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                FuelQuantity -= distance * FuelConsumption;
                Console.WriteLine($"Bus travelled {distance} km");
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

            FuelQuantity += liters;
        }
    }
}