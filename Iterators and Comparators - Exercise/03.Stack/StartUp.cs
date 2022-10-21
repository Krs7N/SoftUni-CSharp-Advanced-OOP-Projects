using System;
using System.Linq;

namespace _03.Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commands = command.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Push")
                {
                    string[] itemsToPush = commands.Skip(1).ToArray();

                    foreach (string item in itemsToPush)
                    {
                        stack.Push(item);
                    }
                }
                else
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, stack));
            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}
