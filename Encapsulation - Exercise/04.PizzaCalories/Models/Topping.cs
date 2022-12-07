namespace _04.PizzaCalories.Models
{
    using System;

    using Utilities;
    public class Topping
    {
        private string toppingType;
        private double grams;

        public Topping(string toppingType, double grams)
        {
            this.ToppingType = toppingType;
            this.Grams = grams;
        }

        private string ToppingType
        {
            get => toppingType;
            set
            {
                if (!IngredientsAndDoughs.IsToppingValid(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidToppingType, value));
                }

                toppingType = value;
            }
        }

        private double Grams
        {
            get => grams;
            set
            {
                if (value < Constants.ToppingMinWeight || value > Constants.ToppingMaxWeight)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidToppingWeight, this.ToppingType, Constants.ToppingMinWeight, Constants.ToppingMaxWeight));
                }

                grams = value;
            }
        }

        public double GetCalories()
        {
            double totalCalories = Constants.ToppingCaloriesPerGram * Grams *
                                   IngredientsAndDoughs.GetToppingModifier(this.ToppingType.ToLower());

            return totalCalories;
        }
    }
}