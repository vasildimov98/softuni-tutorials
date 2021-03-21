namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double INIT_OXYGEN = 70;
        private const int OXYGEN_DECREASE = 5;

        public Biologist(string name)
            : base(name, INIT_OXYGEN)
        {

        }

        public override void Breath()
        {
            if (base.Oxygen - OXYGEN_DECREASE > 0)
            {
                base.Oxygen -= OXYGEN_DECREASE;
            }
            else
            {
                base.Oxygen = 0;
            }
        }
    }
}
