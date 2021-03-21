namespace P00.Demo.Models.Animals
{
    using System;

    using Contracts;

    public abstract class Animal : IAnimal
    {
        private string name;
        private int age;
        private double weight;

        protected Animal(string name, int age, double weight)
        {
            this.Name = name;
            this.Age = age;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value, "Name cannot be null");
                }

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
                    this.ThrowArgumentException("Age cannot be less than zero!");
                }

                this.age = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value <= 0)
                {
                    this.ThrowArgumentException("Weight cannot be less or equal to zero!");
                }

                this.weight = value;
            }
        }
        private void ThrowArgumentException(string msg)
        {
            throw new ArgumentException(msg);
        }
    }
}
