using System;
using System.Collections.Generic;

namespace _04.PizzaCalories.Utilities
{
    public static class IngredientsAndDoughs
    {
        private static readonly IDictionary<string, double> doughsWithModifiers = new Dictionary<string, double>
        {
            { "white" , 1.5 },
            { "wholegrain" , 1.0 },
            { "crispy" , 0.9 },
            { "chewy" , 1.1 },
            { "homemade" , 1.0 }
        };

        private static readonly IDictionary<string, double> toppingTypesWithModifiers = new Dictionary<string, double>
        {
            { "meat" , 1.2 },
            { "veggies" , 0.8 },
            { "cheese" , 1.1 },
            { "sauce" , 0.9 }
        };

        public static bool IsFlourValid(string flourType)
        {
            string givenFlourType = flourType.ToLower();

            if (doughsWithModifiers.ContainsKey(givenFlourType))
            {
                return true;
            }

            return false;
        }

        public static bool IsDoughValid(string doughType)
        {
            string givenDoughType = doughType.ToLower();

            if (doughsWithModifiers.ContainsKey(givenDoughType))
            {
                return true;
            }

            return false;
        }

        public static bool IsToppingValid(string toppingType)
        {
            string givenToppingType = toppingType.ToLower();

            if (toppingTypesWithModifiers.ContainsKey(givenToppingType))
            {
                return true;
            }

            return false;
        }

        public static double GetDoughModifier(string doughOrFlourType)
        {
            string givenDoughOrFloorType = doughOrFlourType.ToLower();

            if (doughsWithModifiers.ContainsKey(givenDoughOrFloorType))
            {
                return doughsWithModifiers[givenDoughOrFloorType];
            }

            throw new ArgumentException();
        }

        public static double GetToppingModifier(string toppingType)
        {
            string givenToppingType = toppingType.ToLower();

            if (toppingTypesWithModifiers.ContainsKey(givenToppingType))
            {
                return toppingTypesWithModifiers[givenToppingType];
            }

            throw new ArgumentException();
        }
    }
}