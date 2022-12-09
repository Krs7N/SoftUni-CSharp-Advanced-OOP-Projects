using System;
using System.Collections.Generic;

namespace _04.WildFarm.Models
{
    using Contracts;

    public class Owl : Bird
    {
        private const double OwlWeightMultiplier = 0.25;

        public Owl(string name, double weight, double wingsize) : base(name, weight, wingsize)
        {
        }

        public override string Name { get; protected set; }

        public override double Weight { get; protected set; }

        public override int FoodEaten { get; protected set; }

        protected override double WeightMultiplier => OwlWeightMultiplier;

        public override IReadOnlyCollection<Type> PrefferedFoods => new HashSet<Type> { typeof(Meat) };

        public override string ProduceSound() => "Hoot Hoot";
    }
}