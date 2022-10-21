using System;

namespace _05.GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();

            int countOfBoxes = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfBoxes; i++)
            {
                string input = Console.ReadLine();

                box.Sentences.Add(input);
            }

            string elementToCompare = Console.ReadLine();

            Console.WriteLine(box.Count(elementToCompare));
        }
    }
}
