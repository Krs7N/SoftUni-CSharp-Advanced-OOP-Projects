namespace _04.PizzaCalories.Models
{
    using System;

    using Utilities;

    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        private string FlourType
        {
            set
            {
                if (!IngredientsAndDoughs.IsFlourValid(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDoughOrFlourType);
                }

                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (!IngredientsAndDoughs.IsDoughValid(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDoughOrFlourType);
                }

                this.bakingTechnique = value;
            }
        }

        private double Grams
        {
            get => this.grams;
            set
            {
                if (value < Constants.DoughMinWeight || value > Constants.DoughMaxWeight)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidDoughWeight, Constants.DoughMinWeight, Constants.DoughMaxWeight));
                }

                this.grams = value;
            }
        }

        public double GetCalories()
        {
            double totalCalories = Constants.DoughCaloriesPerGram * this.Grams *
                                   IngredientsAndDoughs.GetDoughModifier(this.flourType) *
                                   IngredientsAndDoughs.GetDoughModifier(this.bakingTechnique);

            return totalCalories;
        }
    }
}