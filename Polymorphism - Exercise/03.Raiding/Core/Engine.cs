namespace _03.Raiding.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using IO.Contracts;
    using Models;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private IList<Type> heroTypes;
        private IList<BaseHero> heroes;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            heroTypes = new List<Type>{
                typeof(Druid),
                typeof(Rogue),
                typeof(Warrior),
                typeof(Paladin)
            };
            heroes = new List<BaseHero>();
        }

        public void Run()
        {
            int countOfInputs = int.Parse(this.reader.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                string heroName = this.reader.ReadLine();
                string heroType = this.reader.ReadLine();

                Type heroInstanceType = heroTypes.FirstOrDefault(ht => ht.Name == heroType);

                if (heroInstanceType == null)
                {
                    this.writer.WriteLine("Invalid hero!");
                    continue;
                }

                BaseHero hero = Activator.CreateInstance(heroInstanceType, new object[] { heroName }) as BaseHero;
                heroes.Add(hero);
            }

            int bossPower = int.Parse(this.reader.ReadLine());
            int totalPowerSum = 0;

            foreach (var hero in heroes)
            {
                this.writer.WriteLine(hero.CastAbility());
                totalPowerSum += hero.Power;
            }

            this.writer.WriteLine(totalPowerSum >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}