namespace MilitaryElite.Modules
{
    using System.Text;
    using System.Collections.Generic;
    using MilitaryElite.Contracts;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;
        public Commando(string id,
            string firstName,
            string lastName, 
            decimal salary, 
            string coprs)
            : base(id, firstName, lastName, salary, coprs)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => 
            (IReadOnlyCollection<IMission>)this.missions;

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}")
                .AppendLine($"Corps: {this.Corps}")
                .AppendLine("Missions:");

            foreach (var mission in this.missions)
            {
                sb.AppendLine($"  {mission}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
