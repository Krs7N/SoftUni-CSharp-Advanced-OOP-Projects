using System;

namespace _06.GenericCountMethodDouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();

            int countOfBoxes = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfBoxes; i++)
            {
                double input = double.Parse(Console.ReadLine());

                box.Sentences.Add(input);
            }

            double elementToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(box.Count(elementToCompare));
        }
    }
}
