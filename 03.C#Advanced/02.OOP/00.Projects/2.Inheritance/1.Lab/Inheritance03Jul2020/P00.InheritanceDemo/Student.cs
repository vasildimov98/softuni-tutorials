namespace P00.InheritanceDemo
{
    public class Student : Person
    {
        public Student(string name, string address, string school)
            : base(name, address)
        {
            this.School = school;
        }

        public string School { get; set; }

        public void Study()
        {
            System.Console.WriteLine("I am studying");
        }

        public sealed override void Sleep()
        {
            System.Console.WriteLine("I am srudying so no sleeping for me!!!!");
        }
    }
}
