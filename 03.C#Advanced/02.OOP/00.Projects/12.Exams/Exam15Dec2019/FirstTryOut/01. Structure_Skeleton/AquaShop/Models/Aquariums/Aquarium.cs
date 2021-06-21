namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Fish.Contracts;
    using Utilities.Messages;
    using Decorations.Contracts;

    public abstract class Aquarium : IAquarium
    {
        private string name;

        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fish;

        private Aquarium()
        {
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }
        protected Aquarium(string name, int capacity)
            : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }
        public int Capacity { get; }
        public ICollection<IDecoration> Decorations
            => this.decorations.AsReadOnly();
        public ICollection<IFish> Fish
            => this.fish.AsReadOnly();
        public int Comfort 
            => this.decorations
            .Sum(d => d.Comfort);

        public void AddFish(IFish fish)
        {
            if (this.fish.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }
        public bool RemoveFish(IFish fish) => this.fish.Remove(fish);
        public void AddDecoration(IDecoration decoration) => this.decorations.Add(decoration);
        public void Feed()
        {
            foreach (var fish in this.fish)
            {
                fish.Eat();
            }
        }
        public string GetInfo()
        {
            var sb = new StringBuilder();

            var fishInfo = this.fish.Any() ?
                string.Join(", ", this.fish
                .Select(f => f.Name))
                : "none";

            sb
                .AppendLine($"{this.Name} ({this.GetType().Name}):")
                .AppendLine($"Fish: {fishInfo}")
                .AppendLine($"Decorations: {this.decorations.Count}")
                .AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}
