namespace _03.Raiding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;
    using Models.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Type> heroTypes = new List<Type>
            {
                typeof(Druid),
                typeof(Rogue),
                typeof(Warrior),
                typeof(Paladin)
            };

            List<BaseHero> heroes = new List<BaseHero>();

            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                Type heroInstanceType = heroTypes.FirstOrDefault(ht => ht.Name == heroType);

                if (heroInstanceType == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                BaseHero hero = Activator.CreateInstance(heroInstanceType, new object[] { heroName }) as BaseHero;
                heroes.Add(hero);
            }

            int bossPower = int.Parse(Console.ReadLine());
            int totalPowerSum = 0;

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                totalPowerSum += hero.Power;
            }

            Console.WriteLine(totalPowerSum >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}