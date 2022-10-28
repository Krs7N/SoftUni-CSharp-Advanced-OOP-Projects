using System;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while (command != "Beast!")
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (command)
                {
                    case "Cat":
                        Cat cat = new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        Console.WriteLine(cat);
                        break;
                    case "Dog":
                        Dog dog = new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        Console.WriteLine(dog);
                        break;
                    case "Kitten":
                        Kitten kitten = new Kitten(tokens[0], int.Parse(tokens[1]));
                        Console.WriteLine(kitten);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(tokens[0], int.Parse(tokens[1]));
                        Console.WriteLine(tomcat);
                        break;
                    case "Frog":
                        Frog frog = new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        Console.WriteLine(frog);
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                }

                command = Console.ReadLine();
            }
        }
    }
}