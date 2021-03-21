namespace SantaWorkshop.Models.Instruments
{
    using Contracts;
    public class Instrument : IInstrument
    {
        private const int INST_USE_DECR = 10;

        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => this.power;
            private set
            {
                this.power = value > 0 ? value : 0;
            }
        }

        public void Use() 
            => this.Power -= INST_USE_DECR;
        public bool IsBroken()
            => this.Power == 0;

    }
}
