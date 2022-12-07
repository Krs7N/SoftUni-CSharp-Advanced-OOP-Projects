namespace _04.PizzaCalories.Core
{
    using System;

    using Contracts;
    using Models;

    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private Pizza pizza;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            pizza = null;
        }

        public void Run()
        {
            try
            {
                this.ProcessInput();
            }
            catch (ArgumentException e)
            {
                this.writer.WriteLine(e.Message);
            }
        }

        private void ProcessInput()
        {
            string[] pizzaInfo = this.reader.ReadLine().Split();
            string pizzaName = pizzaInfo[1];

            string[] doughInfo = this.reader.ReadLine().Split();
            string flourType = doughInfo[1];
            string bakingTechnique = doughInfo[2];
            double grams = double.Parse(doughInfo[3]);

            Dough dough = new Dough(flourType, bakingTechnique, grams);
            pizza = new Pizza(pizzaName, dough);

            string toppingInfo;
            while ((toppingInfo = this.reader.ReadLine()) != "END")
            {
                string[] toppingTokens = toppingInfo.Split();

                string toppingType = toppingTokens[1];
                double toppingGrams = double.Parse(toppingTokens[2]);

                Topping topping = new Topping(toppingType, toppingGrams);
                this.pizza.AddTopping(topping);
            }

            this.writer.WriteLine($"{pizzaName} - {pizza.GetCalories():f2} Calories.");
        }
    }
}