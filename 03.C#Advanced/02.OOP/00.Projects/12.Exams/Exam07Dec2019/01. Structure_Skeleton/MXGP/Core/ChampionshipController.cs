namespace MXGP.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Repositories;
    using Repositories.Contracts;

    using Models.Races;
    using Models.Riders;
    using Models.Motorcycles;
    using Models.Races.Contracts;
    using Models.Riders.Contracts;
    using Models.Motorcycles.Contracts;

    public class ChampionshipController : IChampionshipController
    {
        private const int MIN_RACERS_PARTICIPANT = 3;

        private readonly IRepository<IRider> riderRepository;
        private readonly IRepository<IMotorcycle> motorcycleRepository;
        private readonly IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            this.riderRepository = new RiderRepository();
            this.motorcycleRepository = new MotorcycleRepository();
            this.raceRepository = new RaceRepository();
        }

        public string CreateRider(string riderName)
        {
            var rider = this.riderRepository.GetByName(riderName);

            if (rider != null)
            {
                throw new ArgumentException($"Rider {rider.Name} is already created.");
            }

            rider = new Rider(riderName);

            this.riderRepository.Add(rider);

            return $"Rider {rider.Name} is created.";
        }
        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var motorcycle = this.motorcycleRepository.GetByName(model);

            if (motorcycle != null)
            {
                throw new ArgumentException($"Motorcycle {motorcycle.Model} is already created.");
            }

            if (nameof(PowerMotorcycle).Contains(type))
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }
            else
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }

            this.motorcycleRepository.Add(motorcycle);

            return $"{motorcycle.GetType().Name} {motorcycle.Model} is created.";
        }
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riderRepository.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            var motorcycle = this.motorcycleRepository.GetByName(motorcycleModel);

            if (motorcycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            rider.AddMotorcycle(motorcycle);

            return $"Rider {rider.Name} received motorcycle {motorcycle.Model}.";
        }
        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            var rider = this.riderRepository.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            race.AddRider(rider);

            return string.Format($"Rider {rider.Name} added in {race.Name} race.");
        }
        public string CreateRace(string name, int laps)
        {
            var race = this.raceRepository.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            race = new Race(name, laps);

            this.raceRepository.Add(race);

            return $"Race {race.Name} is created.";
        }
        public string StartRace(string raceName)
        {
            var race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            var racers = race
                .Riders;

            if (racers.Count < MIN_RACERS_PARTICIPANT)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var fastestRiders = racers
                .OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps))
                .ToArray();

            var firstRider = fastestRiders[0];
            var msg1 = $"Rider {firstRider.Name} wins {race.Name} race.";

            var secondRider = fastestRiders[1];
            var msg2 = $"Rider {secondRider.Name} is second in {race.Name} race.";

            var thirdRider = fastestRiders[2];
            var msg3 = $"Rider {thirdRider.Name} is third in {race.Name} race.";

            var sb = new StringBuilder();

            sb
                .AppendLine(msg1)
                .AppendLine(msg2)
                .AppendLine(msg3);

            this.raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
