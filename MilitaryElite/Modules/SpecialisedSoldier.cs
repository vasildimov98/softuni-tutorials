namespace MilitaryElite.Modules
{
    using System;
    using MilitaryElite.Contracts;
    using MilitaryElite.Enumerators;
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id,
            string firstName,
            string lastName,
            decimal salary,
            string coprs)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = TryParseCorp(coprs);
        }

        public Corps Corps { get; private set; }
        private Corps TryParseCorp(string corpStr)
        {
            var isParse = Enum.TryParse<Corps>(corpStr, out Corps corps);

            if (!isParse)
            {
                throw new ArgumentException();
            }

            return corps;
        }
    }
}
