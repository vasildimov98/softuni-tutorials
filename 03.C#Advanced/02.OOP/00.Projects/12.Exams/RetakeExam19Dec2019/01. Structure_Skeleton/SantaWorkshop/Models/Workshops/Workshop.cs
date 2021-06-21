namespace SantaWorkshop.Models.Workshops
{
    using System;
    using System.Linq;

    using Contracts;
    using Dwarfs.Contracts;
    using Presents.Contracts;

    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }

        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (dwarf.Energy > 0
                && dwarf.Instruments.Any())
            {
                var currInstroment = dwarf
                    .Instruments
                    .First();

                while (!currInstroment.IsBroken()
                    && !present.IsDone()
                    && dwarf.Energy > 0)
                {
                    dwarf.Work();
                    present.GetCrafted();
                    currInstroment.Use();
                }

                if (currInstroment.IsBroken())
                {
                    dwarf.Instruments.Remove(currInstroment);
                }

                if (present.IsDone())
                {
                    break;
                }
            }
        }
    }
}
