using System.Collections.Generic;
using _04.WildFarm.Exceptions;
using _04.WildFarm.Factories;
using _04.WildFarm.Models.Contracts;

namespace _04.WildFarm
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            AnimalFactory animalFactory = new AnimalFactory();
            FoodFactory foodFactory = new FoodFactory();
            HashSet<Animal> animals = new HashSet<Animal>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    Animal animal = animalFactory.CreateAnimal(tokens);

                    string[] foodArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string foodType = foodArgs[0];
                    int foodQty = int.Parse(foodArgs[1]);

                    Food currFood = foodFactory.CreateFood(foodType, foodQty);

                    animals.Add(animal);
                    Console.WriteLine(animal.ProduceSound());
                    animal.Eat(currFood);
                }
                catch (InvalidAnimalTypeException iate)
                {
                    Console.WriteLine(iate.Message);
                }
                catch (InvalidFoodTypeException ifte)
                {
                    Console.WriteLine(ifte.Message);
                }
                catch (FoodNotEatenException fnee)
                {
                    Console.WriteLine(fnee.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
