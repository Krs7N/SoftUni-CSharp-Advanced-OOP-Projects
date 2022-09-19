using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());

            var text = new StringBuilder();
            var memory = new Stack<string>();
            memory.Push(string.Empty);

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (commands[0])
                {
                    case "1":
                        text.Append(commands[1]);
                        memory.Push(text.ToString());
                        break;
                    case "2":
                        int count = int.Parse(commands[1]);
                        text = text.Remove(text.Length - count, count);
                        memory.Push(text.ToString());
                        break;
                    case "3":
                        int index = int.Parse(commands[1]);
                        string textString = text.ToString();
                        Console.WriteLine(textString[index - 1]);
                        break;
                    case "4":
                        memory.Pop();
                        text = new StringBuilder(memory.Peek());
                        break;
                }
            }
        }
    }
}