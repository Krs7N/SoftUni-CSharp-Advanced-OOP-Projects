namespace _03.ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    using Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleTokens = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                for (int i = 0; i < peopleTokens.Length; i += 2)
                {
                    string name = peopleTokens[i];
                    int money = int.Parse(peopleTokens[i + 1]);

                    Person person = new Person(name, money);

                    people.Add(person);
                }

                string[] productTokens = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < productTokens.Length; i += 2)
                {
                    string name = productTokens[i];
                    int cost = int.Parse(productTokens[i + 1]);

                    Product product = new Product(name, cost);

                    products.Add(product);
                }

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string name = tokens[0];
                    string product = tokens[1];

                    Person curPerson = people.Find(p => p.Name == name);
                    Product curProduct = products.Find(p => p.Name == product);

                    if (curPerson.Money >= curProduct.Cost)
                    {
                        curPerson.ReduceMoney(curProduct.Cost);
                        curPerson.AddProduct(curProduct);

                        Console.WriteLine($"{curPerson.Name} bought {curProduct.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{curPerson.Name} can't afford {curProduct.Name}");
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}