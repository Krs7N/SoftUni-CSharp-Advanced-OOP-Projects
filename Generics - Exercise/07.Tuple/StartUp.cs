using System;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] beerInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] numbersInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Tuple<string, string> personInformation = new Tuple<string, string>
            {
                Item1 = $"{personInfo[0]} {personInfo[1]}",
                Item2 = $"{personInfo[2]}"
            };

            Tuple<string, double> nameAndBeer = new Tuple<string, double>
            {
                Item1 = $"{beerInfo[0]}",
                Item2 = double.Parse(beerInfo[1])
            };

            Tuple<int, double> numbers = new Tuple<int, double>
            {
                Item1 = int.Parse(numbersInfo[0]),
                Item2 = double.Parse(numbersInfo[1])
            };

            Console.WriteLine(personInformation);
            Console.WriteLine(nameAndBeer);
            Console.WriteLine(numbers);
        }
    }
}
