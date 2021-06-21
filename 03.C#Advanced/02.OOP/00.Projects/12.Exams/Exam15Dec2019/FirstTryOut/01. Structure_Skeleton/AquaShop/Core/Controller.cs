namespace AquaShop.Core
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;

    using Repositories;

    using Utilities.Messages;

    using Models.Fish;
    using Models.Aquariums;
    using Models.Decorations;
    using Models.Fish.Contracts;
    using Repositories.Contracts;
    using Models.Aquariums.Contracts;
    using Models.Decorations.Contracts;

    public class Controller : IController
    {
        private readonly ICollection<IAquarium> aquariums;
        private readonly IRepository<IDecoration> decorations;

        public Controller()
        {
            this.aquariums = new List<IAquarium>();
            this.decorations = new DecorationRepository();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                this.ThrowInvalidOperationWithMessage(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);

            var result = string.Format(OutputMessages.SuccessfullyAdded, aquariumType);

            return result;
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

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
                this.ThrowInvalidOperationWithMessage(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);

            var result = string.Format(OutputMessages.SuccessfullyAdded, decorationType);

            return result;
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations
                 .FindByType(decorationType);

            if (decoration == null)
            {
                var msg = string.Format(ExceptionMessages.InexistentDecoration, decorationType);
                ThrowInvalidOperationWithMessage(msg);
            }

            var aquarium = this.aquariums
                .First(a => a.Name == aquariumName);

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            var result = string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);

            return result;
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                this.ThrowInvalidOperationWithMessage(ExceptionMessages.InvalidFishType);
            }

            var aquarium = this.aquariums
                .First(a => a.Name == aquariumName);

            var substract = fishType.Substring(0, fishType.Length - 4);

            var aquariumType = aquarium.GetType().Name;

            if (!aquariumType.StartsWith(substract))
            {
                return OutputMessages.UnsuitableWater;
            }

            aquarium.AddFish(fish);

            var outputMsg = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);

            return outputMsg;
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums
                .First(a => a.Name == aquariumName);

            aquarium.Feed();

            var fedCount = aquarium.Fish.Count;

            var outputMsg = string.Format(OutputMessages.FishFed, fedCount);

            return outputMsg;
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums
                 .First(a => a.Name == aquariumName);

            var totalValue = 0m;

            totalValue += aquarium
                .Fish
                .Sum(f => f.Price);

            totalValue += aquarium
                .Decorations
                .Sum(d => d.Price);

            totalValue = Math.Round(totalValue, 2, MidpointRounding.AwayFromZero);

            var outputMsg = string.Format(OutputMessages.AquariumValue, aquariumName, totalValue);

            return outputMsg;
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

        private void ThrowInvalidOperationWithMessage(string message)
        {
            throw new InvalidOperationException(message);
        }
    }
}
