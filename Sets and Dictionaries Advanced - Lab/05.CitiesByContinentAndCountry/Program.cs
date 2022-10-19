using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var citiesByCountriesByContinents = new Dictionary<string, Dictionary<string, List<string>>>();

            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (!citiesByCountriesByContinents.ContainsKey(continent))
                {
                    citiesByCountriesByContinents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!citiesByCountriesByContinents[continent].ContainsKey(country))
                {
                    citiesByCountriesByContinents[continent].Add(country, new List<string>());
                }

                citiesByCountriesByContinents[continent][country].Add(city);
            }

            foreach (var citiesByCountriesByContinent in citiesByCountriesByContinents)
            {
                Console.WriteLine($"{citiesByCountriesByContinent.Key}:");

                foreach (var citiesByCountries in citiesByCountriesByContinent.Value)
                {
                    Console.WriteLine($"  {citiesByCountries.Key} -> {string.Join(", ",citiesByCountries.Value)}");
                }
            }
        }
    }
}