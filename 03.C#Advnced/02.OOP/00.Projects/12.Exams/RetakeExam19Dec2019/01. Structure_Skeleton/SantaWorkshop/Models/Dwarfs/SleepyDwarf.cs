namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int INIT_ENERGY = 50;
        private const int ENERGY_DECREASE = 5;

        public SleepyDwarf(string name)
            : base(name, INIT_ENERGY)
        {

        }

        public override void Work()
        {
            base.Work();
            this.Energy -= ENERGY_DECREASE;
        }
    }
}
