using System;
using System.Linq;

namespace _05.FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfInputs = int.Parse(Console.ReadLine());

            Person[] people = new Person[countOfInputs];

            for (int i = 0; i < countOfInputs; i++)
            {
                string[] personData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people[i] = new Person
                {
                    Name = personData[0],
                    Age = int.Parse(personData[1])
                };
            }

            string condition = Console.ReadLine();
            int ageCondition = int.Parse(Console.ReadLine());

            people = condition == "older" ? people.Where(p => p.Age >= ageCondition).ToArray() : people.Where(p => p.Age < ageCondition).ToArray();

            string[] format = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (format.Length == 2)
            {
                foreach (var person in people)
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }
            else
            {
                foreach (var person in people)
                {
                    if (format[0] == "name")
                    {
                        Console.WriteLine(person.Name);
                    }
                    else
                    {
                        Console.WriteLine(person.Age);
                    }
                }
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}