using System;
using System.Collections.Generic;

namespace _04.WildFarm.Models
{
    using Contracts;

    public class Cat : Feline
    {
        private const double CatWeightMultiplier = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string Name { get; protected set; }

        public override double Weight { get; protected set; }

        public override int FoodEaten { get; protected set; }

        protected override double WeightMultiplier => CatWeightMultiplier;

        public override IReadOnlyCollection<Type> PrefferedFoods => new HashSet<Type> { typeof(Vegetable), typeof(Meat) };

        public override string Breed { get; protected set; }

        public override string ProduceSound() => "Meow";
    }
}