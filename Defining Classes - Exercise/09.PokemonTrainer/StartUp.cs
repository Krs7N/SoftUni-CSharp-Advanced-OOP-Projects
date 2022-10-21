using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();
            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                ReadNewTrainerInfo(trainers, input);
            }
            while ((input = Console.ReadLine()) != "End")
            {
                ReadCommands(trainers, input);
            }
            foreach (Trainer trainer in trainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }

        static void ReadNewTrainerInfo(List<Trainer> trainers, string input)
        {
            var command = new Queue<string>(input.Split());
            string trainerName = command.Dequeue();
            string pokemonName = command.Dequeue();
            string pokemonElement = command.Dequeue();
            int pokemonHealth = int.Parse(command.Dequeue());

            if (trainers.Any(t => t.Name == trainerName))
            {
                trainers
                    .Find(t => t.Name == trainerName).Pokemons
                    .Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            }
            else
            {
                trainers.Add(new Trainer(trainerName, pokemonName, pokemonElement, pokemonHealth));
            }
        }

        static void ReadCommands(List<Trainer> trainers, string command)
        {
            for (int i = 0; i < trainers.Count; i++)
            {
                if (trainers[i].Pokemons.Any(p => p.Element == command))
                {
                    trainers[i].Badges++;
                }
                else
                {
                    DecreasePokemonsLifeBy10(trainers[i].Pokemons);
                }
            }
        }

        static void DecreasePokemonsLifeBy10(List<Pokemon> pokemons)
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                pokemons[i].Health -= 10;
                if (pokemons[i].Health <= 0)
                    pokemons.RemoveAt(i);
            }
        }
    }
}