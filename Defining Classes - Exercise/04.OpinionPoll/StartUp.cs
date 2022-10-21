using System;
using System.Collections.Generic;
using System.Linq;
using _03.OldestFamilyMember;

namespace _04.OpinionPoll
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                string[] personData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(personData[0], int.Parse(personData[1]));

                people.Add(person);
            }

            people = people.Where(p => p.Age > 30).OrderBy(p => p.Name).ThenByDescending(p => p.Age).ToList();

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}