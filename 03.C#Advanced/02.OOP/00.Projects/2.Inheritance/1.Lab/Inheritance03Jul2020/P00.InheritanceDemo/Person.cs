namespace P00.InheritanceDemo
{
    using System;
    public class Person : Object
    {
        private string name;

        public Person()
        {

        }

        public Person(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }

        public virtual string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value, "Parameter cannot be null or whitespace!");
                }

                this.name = value;
            }
        }
        public string Address { get; set; }

        public virtual void Sleep()
        {
            Console.WriteLine("I am sleeping!");
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
