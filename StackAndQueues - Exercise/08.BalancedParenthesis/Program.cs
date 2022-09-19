using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parenthesis = Console.ReadLine();
            var stack = new Stack<char>();

            foreach (var ch in parenthesis)
            {
                if (stack.Any())
                {
                    char symbol = stack.Peek();

                    if (symbol == '{' && ch == '}')
                    {
                        stack.Pop();
                        continue;
                    }

                    if (symbol == '(' && ch == ')')
                    {
                        stack.Pop();
                        continue;
                    }

                    if (symbol == '[' && ch == ']')
                    {
                        stack.Pop();
                        continue;
                    }
                }

                stack.Push(ch);
            }

            Console.WriteLine(stack.Any() ? "NO" : "YES");
        }
    }
}
