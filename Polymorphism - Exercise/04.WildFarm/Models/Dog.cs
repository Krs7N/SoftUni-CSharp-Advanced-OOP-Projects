using System;
using System.Collections.Generic;

namespace _04.WildFarm.Models
{
    using Contracts;

    public class Dog : Mammal
    {
        public const double DogWeightMultiplier = 0.4;

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string Name { get; protected set; }

        public override double Weight { get; protected set; }

        public override int FoodEaten { get; protected set; }

        protected override double WeightMultiplier => DogWeightMultiplier;

        public override IReadOnlyCollection<Type> PrefferedFoods => new HashSet<Type> { typeof(Meat) };

        public override string ProduceSound() => "Woof!";

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}