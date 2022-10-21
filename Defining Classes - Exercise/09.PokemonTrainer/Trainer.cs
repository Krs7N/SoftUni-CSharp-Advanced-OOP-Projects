using System.Collections.Generic;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        private int badges;
        private string name;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            Name = name;
            Pokemons = new List<Pokemon>();
        }

        public Trainer(string trainerName, string pokemonName, string element, int health)
            : this(trainerName)
        {
            Pokemons.Add(new Pokemon(pokemonName, element, health));
        }

        public int Badges
        {
            get { return badges; }
            set { badges = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }
    }
}