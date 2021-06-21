namespace EncapsulationDemo
{
    using System;
    using System.Collections.Generic;
    public class Cat
    {
        private string name;
        private readonly ICollection<string> toys;

        public Cat(string name)
        {
            this.Name = name;

            this.toys = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value, "Value cannot be null!");
                }

                this.name = value;
            }
        }
        public IReadOnlyCollection<string> Toys
            => (IReadOnlyCollection<string>)this.toys;
        
        public void Sleep()
        {

        }
    }
}
