namespace _01.Vehicles.Models.Contracts
{
    public abstract class Vehicle
    {
        public abstract double FuelQuantity { get; set; }

        public abstract double FuelConsumption { get; }

        public abstract void Drive(double distance);

        public abstract void Refuel(double liters);
    }
}