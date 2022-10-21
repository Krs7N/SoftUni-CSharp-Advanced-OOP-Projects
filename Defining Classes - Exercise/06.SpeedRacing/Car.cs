using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionFor1Km)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionFor1Km;
            TraveledDistance = 0;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TraveledDistance { get; set; }

        public void Drive(double distanceTraveled)
        {
            if (FuelConsumptionPerKilometer * distanceTraveled <= FuelAmount)
            {
                FuelAmount -= FuelConsumptionPerKilometer * distanceTraveled;
                TraveledDistance += distanceTraveled;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}