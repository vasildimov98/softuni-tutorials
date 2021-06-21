using System.Collections.Generic;

namespace P09.PokemonTrainer
{
    public class Trainers
    {
        public Trainers(string name)
        {
            this.Name = name;
            this.NumberOfBadges = 0;
            this.MyPokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> MyPokemons { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.MyPokemons.Count}";
        }
    }
}
