using System;
using System.Collections.Generic;

namespace _04.WildFarm.Models
{
    using Contracts;

    public class Hen : Bird
    {
        private const double HenWeightMultiplier = 0.35;

        public Hen(string name, double weight, double wingsize) : base(name, weight, wingsize)
        {
        }

        public override string Name { get; protected set; }

        public override double Weight { get; protected set; }

        public override int FoodEaten { get; protected set; }

        protected override double WeightMultiplier => HenWeightMultiplier;

        public override IReadOnlyCollection<Type> PrefferedFoods => new HashSet<Type> { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };

        public override string ProduceSound() => "Cluck";
    }
}