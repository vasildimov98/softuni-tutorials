namespace SantaWorkshop.Core
{
    using System;
    using System.Text;
    using System.Linq;

    using Contracts;
    using Repositories;
    using Models.Dwarfs;
    using Models.Presents;
    using Models.Workshops;
    using Utilities.Messages;
    using Models.Instruments;
    using Models.Dwarfs.Contracts;

    public class Controller : IController
    {
        private readonly DwarfRepository dwarfs;
        private readonly PresentRepository presents;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;

            if (dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType == "SleepyDwarf")
            {
                dwarf = new SleepyDwarf(dwarfName);
            }
            else
            {
               this.ThrowInvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            this.dwarfs.Add(dwarf);

            var outputMessage = string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);

            return outputMessage;
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            var dwarf = this.dwarfs
                .FindByName(dwarfName);

            if (dwarf == null)
            {
                this.ThrowInvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            var instrument = new Instrument(power);

            dwarf.AddInstrument(instrument);

            var outputMessage = string.Format(OutputMessages.InstrumentAdded, power, dwarfName);

            return outputMessage;
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            var present = new Present(presentName, energyRequired);

            this.presents.Add(present);

            var outputMessage = string.Format(OutputMessages.PresentAdded, presentName);

            return outputMessage;
        }

        public string CraftPresent(string presentName)
        {
            if (presentName == "LegoSet")
            {

            }

            var present = this.presents
                .FindByName(presentName);

            var readyDwarfs = this.dwarfs
                .Models
                .Where(dw => dw.Energy >= 50)
                .OrderByDescending(dw => dw.Energy)
                .ToList();

            if (!readyDwarfs.Any())
            {
                this.ThrowInvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            var workshop = new Workshop();

            while (readyDwarfs.Any() && !present.IsDone())
            {
                var currDwarf = readyDwarfs[0];

                workshop.Craft(present, currDwarf);

                if (currDwarf.Energy == 0 
                    || !currDwarf.Instruments.Any())
                {
                    readyDwarfs.Remove(currDwarf);
                }
            }

            string outputMessage;
            if (present.IsDone())
            {
                outputMessage = string.Format(OutputMessages.PresentIsDone, presentName);
            }
            else
            {
                outputMessage = string.Format(OutputMessages.PresentIsNotDone, presentName);
            }

            return outputMessage;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            var countCraftedPresents = this.presents
                .Models
                .Where(p => p.IsDone() == true)
                .Count();

            sb
                .AppendLine($"{countCraftedPresents} presents are done!")
                .AppendLine($"Dwarfs info:");

            foreach (var dwarf in this.dwarfs.Models)
            {
                sb.AppendLine(dwarf.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        private void ThrowInvalidOperationException(string message)
        {
            throw new InvalidOperationException(message);
        }
    }
}
