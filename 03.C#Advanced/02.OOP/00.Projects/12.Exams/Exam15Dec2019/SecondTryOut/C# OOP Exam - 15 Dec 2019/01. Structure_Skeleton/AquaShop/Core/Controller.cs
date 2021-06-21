namespace AquaShop.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Repositories;
    using Models.Aquariums;
    using Utilities.Messages;
    using Models.Decorations;
    using Repositories.Contracts;
    using Models.Aquariums.Contracts;
    using Models.Decorations.Contracts;
    using System.Linq;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Models.Fish;
    using System.Text;

    public class Controller : IController
    {
        private const string FRESHWATER_AQUARIUM = "FreshwaterAquarium";
        private const string SALTWATER_AQUARIUM = "SaltwaterAquarium";

        private readonly IRepository<IDecoration> decorations;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != FRESHWATER_AQUARIUM && aquariumType != SALTWATER_AQUARIUM)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            IAquarium aquarium;
            if (aquariumType == FRESHWATER_AQUARIUM)
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            this.aquariums.Add(aquarium);

            var msg = string.Format(OutputMessages.SuccessfullyAdded, aquariumType);

            return msg;
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;
            if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);

            var msg = string.Format(OutputMessages.SuccessfullyAdded, decorationType);

            return msg;
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var desiredDecoration = this.decorations
                .FindByType(decorationType);

            if (desiredDecoration == null)
            {
                var exMsg = string.Format(ExceptionMessages.InexistentDecoration, decorationType);

                throw new InvalidOperationException(exMsg);
            }

            var aquarium = this.aquariums
               .First(a => a.Name == aquariumName);

            aquarium.AddDecoration(desiredDecoration);
            this.decorations.Remove(desiredDecoration);

            var outMsg = string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);

            return outMsg;
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aquarium = this.aquariums
                .First(a => a.Name == aquariumName);

            IFish fish;
            string msg;
            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);

                if (aquarium.GetType().Name.Contains("Freshwater"))
                {
                    aquarium.AddFish(fish);
                    msg = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
                else
                {
                    msg = OutputMessages.UnsuitableWater;
                }
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);

                if (aquarium.GetType().Name.Contains("Saltwater"))
                {
                    aquarium.AddFish(fish);
                    msg = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
                else
                {
                    msg = OutputMessages.UnsuitableWater;
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            return msg;
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums
                .First(a => a.Name == aquariumName);

            aquarium.Feed();

            var msg = string.Format(OutputMessages.FishFed, aquarium.Fish.Count);

            return msg;
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums
                .First(a => a.Name == aquariumName);

            var value = aquarium
                .Fish
                .Sum(f => f.Price)
                + aquarium
                .Decorations
                .Sum(d => d.Price);

            var msg = string.Format(OutputMessages.AquariumValue, aquariumName, value.ToString("F2"));

            return msg;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
