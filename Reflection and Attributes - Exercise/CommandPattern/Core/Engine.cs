using System;

namespace CommandPattern.Core
{
    using Contracts;
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter cmdInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.cmdInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string inputLine = Console.ReadLine();
            string result = cmdInterpreter.Read(inputLine);
            Console.WriteLine(result);
        }
    }
}