namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;

    using Planets;
    using Astronauts.Contracts;
    using System.Linq;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (astronauts.Any(a => a.CanBreath)
                && planet.Items.Any())
            {
                var currAstronaut = astronauts
                    .First(a => a.CanBreath);

                var currItem = planet
                    .Items
                    .First();

                currAstronaut.Breath();
                currAstronaut.Bag.Items.Add(currItem);

                planet.Items.Remove(currItem);
            }
        }
    }
}
