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

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.Decorations = new List<IDecoration>();
            this.Fish = new List<IFish>();
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

        public int Comfort
            => this.Decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count + 1 > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.Fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
            => this.Fish.Remove(fish);

        public void AddDecoration(IDecoration decoration)
            => this.Decorations.Add(decoration);

        public void Feed()
            => this.Fish
            .ToList()
            .ForEach(f => f.Eat());

        public string GetInfo()
        {
            var sb = new StringBuilder();

            var fishInfo = this.Fish.Any() ?
                string.Join(", ", this.Fish) :
                "none";

            sb
                .AppendLine($"{this.Name} ({this.GetType().Name}):")
                .AppendLine($"Fish: {fishInfo}")
                .AppendLine($"Decorations: {this.Decorations.Count}")
                .AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}
