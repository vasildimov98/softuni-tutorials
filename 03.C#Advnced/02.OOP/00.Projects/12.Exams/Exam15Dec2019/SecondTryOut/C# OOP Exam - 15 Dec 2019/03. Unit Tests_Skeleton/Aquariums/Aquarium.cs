namespace Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Aquarium
    {
        private string name;
        private int capacity;
        private List<Fish> fish;

        //TODO - done
        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.fish = new List<Fish>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                //TODO - done
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "Invalid aquarium name!");
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                //TODO - done
                if (value < 0)
                {
                    throw new ArgumentException("Invalid aquarium capacity!");
                }

                this.capacity = value;
            }
        }

        public int Count => this.fish.Count;

        public void Add(Fish fish)
        {
            //TODO - done
            if (this.fish.Count == this.capacity)
            {
                throw new InvalidOperationException("Aquarium is full!");
            }

            //TODO - done
            this.fish.Add(fish);
        }

        public void RemoveFish(string name)
        {
            //TODO - done
            Fish fishToRemove = this.fish.FirstOrDefault(x => x.Name == name);

            if (fishToRemove == null)
            {
                throw new InvalidOperationException($"Fish with the name {name} doesn't exist!");
            }

            //TODO - done
            this.fish.Remove(fishToRemove);
        }

        public Fish SellFish(string name)
        {
            //TODO - done
            Fish requestedFish = this.fish.FirstOrDefault(x => x.Name == name);

            if (requestedFish == null)
            {
                throw new InvalidOperationException($"Fish with the name {name} doesn't exist!");
            }

            //TODO - done
            requestedFish.Available = false;
            //TODO - done
            return requestedFish;
        }

        //TODO - done
        public string Report()
        {
            string fishNames = string.Join(", ", this.fish.Select(f => f.Name));
            string report = $"Fish available at {this.Name}: {fishNames}";

            return report;
        }
    }
}
