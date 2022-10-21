using System;

namespace _01.GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.Sentences.Add(input);
            }

            Console.WriteLine(box);
        }
    }
}