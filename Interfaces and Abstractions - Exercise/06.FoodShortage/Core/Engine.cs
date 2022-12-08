namespace _06.FoodShortage.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using IO.Contracts;
    using Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IList<string> peopleNames;
        private readonly IList<Citizen> citizens;
        private readonly IList<Rebel> rebels;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.peopleNames = new List<string>();
            this.citizens = new List<Citizen>();
            this.rebels = new List<Rebel>();
        }

        public void Run()
        {
            int numberOfPeople = int.Parse(this.reader.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personTokens = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (personTokens.Length == 4)
                {
                    Citizen citizen = new Citizen(personTokens[0], int.Parse(personTokens[1]), personTokens[2],
                        personTokens[3]);
                    peopleNames.Add(citizen.Name);
                    citizens.Add(citizen);
                }
                else
                {
                    Rebel rebel = new Rebel(personTokens[0], int.Parse(personTokens[1]), personTokens[2]);
                    peopleNames.Add(rebel.Name);
                    rebels.Add(rebel);
                }
            }

            string personBoughtFood;
            int totalBoughtFood = 0;

            while ((personBoughtFood = this.reader.ReadLine()) != "End")
            {
                PeopleBuyingFood(personBoughtFood);
            }

            totalBoughtFood = TotalFoodCalculator(citizens, rebels, totalBoughtFood);

            this.writer.WriteLine(totalBoughtFood);
        }

        private void PeopleBuyingFood(string personBoughtFood)
        {
            if (peopleNames.Contains(personBoughtFood))
            {
                Citizen searchedCitizen = citizens.FirstOrDefault(c => c.Name == personBoughtFood);

                if (searchedCitizen != null)
                {
                    searchedCitizen.BuyFood();
                }

                Rebel searchedRebel = rebels.FirstOrDefault(r => r.Name == personBoughtFood);

                if (searchedRebel != null)
                {
                    searchedRebel.BuyFood();
                }
            }
        }

        private int TotalFoodCalculator(IList<Citizen> citizens, IList<Rebel> rebels, int totalFood)
        {
            foreach (var citizen in citizens)
            {
                totalFood += citizen.Food;
            }

            foreach (var rebel in rebels)
            {
                totalFood += rebel.Food;
            }

            return totalFood;
        }
    }
}