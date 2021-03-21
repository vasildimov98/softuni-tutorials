namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const double INIT_OXYGEN = 90;
        public Meteorologist(string name)
            : base(name, INIT_OXYGEN)
        {

        }
    }
}
