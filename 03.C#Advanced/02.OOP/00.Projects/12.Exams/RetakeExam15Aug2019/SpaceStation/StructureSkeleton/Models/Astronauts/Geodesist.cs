namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const double INIT_OXYGEN = 50;
        public Geodesist(string name)
            : base(name, INIT_OXYGEN)
        {

        }
    }
}
