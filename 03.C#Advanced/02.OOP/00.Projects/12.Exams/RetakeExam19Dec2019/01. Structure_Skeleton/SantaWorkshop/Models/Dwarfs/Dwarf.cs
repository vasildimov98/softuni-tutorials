namespace SantaWorkshop.Models.Dwarfs
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;
    using Instruments.Contracts;
    using System.Text;

    public abstract class Dwarf : IDwarf
    {
        private const int WORK_ENERGY_DECR = 10;

        private string name;
        private int energy;

        private Dwarf()
        {
            this.Instruments = new List<IInstrument>();
        }

        protected Dwarf(string name, int energy)
            : this()
        {
            this.Name = name;
            this.Energy = energy;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }

                this.name = value;
            }
        }
        public int Energy
        {
            get => this.energy;
            protected set
            {
                this.energy = value > 0 ? value : 0;
            }
        }
        public ICollection<IInstrument> Instruments { get; }

        public virtual void Work() =>
            this.Energy -= WORK_ENERGY_DECR;

        public void AddInstrument(IInstrument instrument)
            => this.Instruments.Add(instrument);

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"Name: {this.Name}")
                .AppendLine($"Energy: {this.Energy}")
                .AppendLine($"Instruments: {this.Instruments.Count} not broken left");

            return sb.ToString().TrimEnd();
        }
    }
}
