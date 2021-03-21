namespace P06.PokemonTrainer
{
    using System.Collections.Generic;
    using System.Linq;

    public class Trainer
    {
        private List<Pokemon> pokemons;

        private Trainer()
        {
            this.pokemons = new List<Pokemon>();
        }
        public Trainer(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public IReadOnlyCollection<Pokemon> Pokemons
            => this.pokemons.AsReadOnly();
        public int Count => this.pokemons.Count;
        public void AddPokemon(Pokemon pokemon)
        {
            this.pokemons.Add(pokemon);
        }

        public void FightWithPokemon(string element)
        {
            if (this.Pokemons.Any(p => p.Element == element))
            {
                this.NumberOfBadges++;
            }
            else
            {
                DecreaseHealth();
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.Count}";
        }

        private void DecreaseHealth()
        {
            foreach (var pokemon in this.pokemons)
            {
                pokemon.Health -= 10;
            }

            this.pokemons.RemoveAll(p => p.Health <= 0);
        }
    }
}
