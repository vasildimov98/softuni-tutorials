namespace P00.InheritanceDemo
{
    public class Employee : Person
    {
        public Employee()
        {
        }

        public Employee(string name, string address, string company)
            : base(name, address)
        {
            this.Company = company;
        }

        public string Company { get; set; }

        public void Fire(string reasons)
        {
            System.Console.WriteLine($"{base.Name} got fired because of {reasons}");
        }
    }
}
