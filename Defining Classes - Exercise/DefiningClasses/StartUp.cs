using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);

            Person secondPerson = new Person(20);

            Console.WriteLine(secondPerson.Name);
            Console.WriteLine(secondPerson.Age);

            Person thirdPerson = new Person("George", 15);

            Console.WriteLine(thirdPerson.Name);
            Console.WriteLine(thirdPerson.Age);
        }
    }
}