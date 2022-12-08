namespace _05.BirthdayCelebrations.Core
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
        private readonly IList<string> birthdates;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.birthdates = new List<string>();
        }

        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] entityTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (entityTokens[0])
                {
                    case "Citizen":
                        ICitizen citizen = new Citizen(entityTokens[1], int.Parse(entityTokens[2]), entityTokens[3],
                            entityTokens[4]);
                        this.birthdates.Add(citizen.Birthdate);
                        break;
                    case "Pet":
                        IPet pet = new Pet(entityTokens[1], entityTokens[2]);
                        this.birthdates.Add(pet.Birthdate);
                        break;
                    case "Robot":
                        IRobot robot = new Robot(entityTokens[1], entityTokens[2]);
                        break;
                }
            }

            string birthYear = this.reader.ReadLine();

            IList<string> birthYearEntities = birthdates.Where(e => e.EndsWith(birthYear)).ToList();

            foreach (var birthYearEntity in birthYearEntities)
            {
                this.writer.WriteLine(birthYearEntity);
            }
        }
    }
}