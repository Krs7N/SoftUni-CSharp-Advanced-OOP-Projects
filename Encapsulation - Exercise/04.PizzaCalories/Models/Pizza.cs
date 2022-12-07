namespace _04.PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Utilities;

    public class Pizza
    {
        private string name;
        private IList<Topping> toppings;
        private readonly Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > Constants.PizzaMaxNameLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPizzaName, Constants.PizzaMinNameLength, Constants.PizzaMaxNameLength));
                }

                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);

            if (toppings.Count > Constants.PizzaMaxToppingsCount)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCountPizzaToppings, Constants.PizzaMinToppingsCount, Constants.PizzaMaxToppingsCount));
            }
        }

        public double GetCalories() => dough.GetCalories() + toppings.Sum(t => t.GetCalories());
    }
}