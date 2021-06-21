namespace SpaceStation.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Common;
    using Contracts;
    using Repositories;
    using Repositories.Contracts;

    using Models.Planets;
    using Models.Mission;
    using Models.Astronauts;
    using Models.Astronauts.Contracts;

    public class Controller : IController
    {
        private int countOfExploredPlanets;

        private readonly IRepository<IAstronaut> astronautRepository;
        private readonly IRepository<IPlanet> planetRepository;
        private readonly IMission mission;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.INVALID_ASTRONAUT_TYPE);
            }

            this.astronautRepository.Add(astronaut);

            return string.Format(OutputMessages.SUCCESSFULLY_ADDED_ASTRONAUT, astronaut.GetType().Name, astronaut.Name);
        }
        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepository.Add(planet);

            return string.Format(OutputMessages.SUCCESSFULLY_ADDED_PLANET, planet.Name);
        }
        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronautRepository
                .FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MISSING_ASTRONAUT, astronautName));
            }

            this.astronautRepository.Remove(astronaut);

            return string.Format(OutputMessages.SUCCESSFULLY_REMOVED_ASTRONAUT, astronaut.Name);
        }
        public string ExplorePlanet(string planetName)
        {
            var suitableAstronauts = this.astronautRepository
                 .Models
                 .Where(a => a.Oxygen > 60)
                 .ToList();

            if (!suitableAstronauts.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NOT_ENOUGHT_ASTRONAUT);
            }

            var planet = this.planetRepository.FindByName(planetName);

            this.mission.Explore(planet, suitableAstronauts);

            countOfExploredPlanets++;

            return string.Format(OutputMessages.MISSION_COMPLETE,
                planet.Name,
                suitableAstronauts
                .Count(a => !a.CanBreath));
        }
        public string Report()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine(string.Format(OutputMessages.PLANET_EXPLORED, countOfExploredPlanets))
                .AppendLine(OutputMessages.ASTRONAUT_INFO);

            foreach (var astronaut in this.astronautRepository.Models)
            {
                var astronautBagInfo = astronaut
                    .Bag
                    .Items
                    .Count > 0 ?
                    string.Join(", ", astronaut.Bag.Items) :
                    "none";

                sb
                   .AppendLine(string.Format(OutputMessages.ASTRONAUT_NAME, astronaut.Name))
                   .AppendLine(string.Format(OutputMessages.ASTRONAUT_OXYGEN, astronaut.Oxygen))
                   .AppendLine(string.Format(OutputMessages.ASTRONAUT_Bag, astronautBagInfo));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
