namespace _04.BorderControl.Core
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
        private readonly IList<string> ids;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.ids = new List<string>();
        }

        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] entityTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (entityTokens.Length == 3)
                {
                    ICitizen citizen = new Citizen(entityTokens[0], int.Parse(entityTokens[1]), entityTokens[2]);
                    this.ids.Add(citizen.Id);
                }
                else
                {
                    IRobot robot = new Robot(entityTokens[0], entityTokens[1]);
                    this.ids.Add(robot.Id);
                }
            }

            string fakeId = this.reader.ReadLine();

            IList<string> fakeEntities = ids.Where(e => e.EndsWith(fakeId)).ToList();

            foreach (var fakeEntity in fakeEntities)
            {
                this.writer.WriteLine(fakeEntity);
                this.ids.Remove(fakeEntity);
            }
        }
    }
}