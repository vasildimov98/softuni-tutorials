namespace PolymorphismDemo
{
    using System;
    public abstract class Mammal : IAnimal
    {
        private string name;

        protected Mammal(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Value cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public abstract string Breathe();
        public string Sleep()
        {
            return "I am sleeping!";
        }
    }
}
