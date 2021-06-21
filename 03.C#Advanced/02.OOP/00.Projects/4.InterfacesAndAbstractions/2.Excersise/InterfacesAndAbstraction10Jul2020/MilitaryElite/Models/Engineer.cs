namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Enumerators;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly ICollection<IRepair> repairs;
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs 
            => (IReadOnlyCollection<IRepair>)this.repairs;

        public void AddReapir(IRepair repair)
            => this.repairs.Add(repair);

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine(base.ToString())
                .AppendLine("Repairs:");

            foreach (var repair in this.Repairs)
            {
                sb.AppendLine($"  {repair}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
