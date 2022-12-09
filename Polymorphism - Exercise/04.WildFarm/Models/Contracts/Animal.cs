using System;
using System.Collections.Generic;
using System.Linq;
using _04.WildFarm.Exceptions;

namespace _04.WildFarm.Models.Contracts
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public abstract string Name { get; protected set; }

        public abstract double Weight { get; protected set; }

        public abstract int FoodEaten { get; protected set; }

        protected abstract double WeightMultiplier { get; }

        public abstract IReadOnlyCollection<Type> PrefferedFoods { get; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            if (this.PrefferedFoods.All(t => food.GetType().Name != t.Name))
            {
                throw new FoodNotEatenException(string.Format(ExceptionMessages.FoodNotEatenExceptionMessage, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += food.Quantity * this.WeightMultiplier;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}