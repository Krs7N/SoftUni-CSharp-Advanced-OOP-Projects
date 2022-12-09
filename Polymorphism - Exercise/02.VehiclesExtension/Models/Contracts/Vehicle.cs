namespace _02.VehiclesExtension.Models.Contracts
{
    public abstract class Vehicle
    {
        public abstract double FuelQuantity { get; set; }

        public abstract double FuelConsumption { get; }

        public abstract double TankCapacity { get; }

        public abstract void Drive(double distance);

        public abstract void Refuel(double liters);
    }
}