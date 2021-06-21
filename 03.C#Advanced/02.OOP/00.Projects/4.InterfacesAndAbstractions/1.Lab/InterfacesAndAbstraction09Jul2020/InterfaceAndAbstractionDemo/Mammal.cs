using System;

namespace InterfaceAndAbstractionDemo
{
    public abstract class Mammal : IAnimal
    {
        private string name;
        private int age;

        protected Mammal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                this.ValidateName(value);

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative!");
                }

                this.age = value;
            }
        }

        public abstract void Play(string toy);

        public virtual void Sleep()
        {
            Console.WriteLine("I am sleeping...");
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(name, "Name cannot be null!");
            }
        }
    }
}
