using System;
using System.Collections.Generic;

namespace _04.WildFarm.Models
{
    using Contracts;

    public class Mouse : Mammal
    {
        private const double MouseWeightMultiplier = 0.1;

        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string Name { get; protected set; }

        public override double Weight { get; protected set; }

        public override int FoodEaten { get; protected set; }

        protected override double WeightMultiplier => MouseWeightMultiplier;

        public override IReadOnlyCollection<Type> PrefferedFoods => new HashSet<Type> { typeof(Vegetable), typeof(Fruit) };

        public override string ProduceSound() => "Squeak";

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}