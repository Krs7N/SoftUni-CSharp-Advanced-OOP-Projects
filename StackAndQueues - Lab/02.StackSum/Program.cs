using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var stack = new Stack<int>(input);

            var commands = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "end")
            {
                switch (commands[0])
                {
                    case "add":
                        Add(stack, commands);
                        break;
                    case "remove":
                        Remove(stack, commands);
                        break;
                }

                commands = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }

        static void Add(Stack<int> stack, string[] commands)
        {
            int firstNumber = int.Parse(commands[1]);
            int secondNumber = int.Parse(commands[2]);
            stack.Push(firstNumber);
            stack.Push(secondNumber);
        }

        static void Remove(Stack<int> stack, string[] commands)
        {
            int countOfNumbersToRemove = int.Parse(commands[1]);
            if (countOfNumbersToRemove <= stack.Count)
            {
                for (int i = 0; i < countOfNumbersToRemove; i++)
                {
                    stack.Pop();
                }
            }
        }
    }
}