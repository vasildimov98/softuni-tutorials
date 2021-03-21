namespace MilitaryElite.Modules
{
    using MilitaryElite.Contracts;
    public class Private : Soldier, IPrivate
    {
        private string id;
        private string firstName;
        private string lastName;

        public Private(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}";
        }
    }
}
