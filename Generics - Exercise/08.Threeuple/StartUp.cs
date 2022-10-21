using System;

namespace _08.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] beerInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] numbersInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, string, string> personInformation = new Threeuple<string, string, string>
            {
                Item1 = $"{personInfo[0]} {personInfo[1]}",
                Item2 = personInfo[2],
                Item3 = personInfo[3]
            };

            Threeuple<string, double, bool> nameAndBeer = new Threeuple<string, double, bool>
            {
                Item1 = $"{beerInfo[0]}",
                Item2 = double.Parse(beerInfo[1]),
                Item3 = beerInfo[2] == "drunk"
            };

            Threeuple<string, double, string> numbers = new Threeuple<string, double, string>
            {
                Item1 = numbersInfo[0],
                Item2 = double.Parse(numbersInfo[1]),
                Item3 = numbersInfo[2]
            };

            Console.WriteLine(personInformation);
            Console.WriteLine(nameAndBeer);
            Console.WriteLine(numbers);
        }
    }
}