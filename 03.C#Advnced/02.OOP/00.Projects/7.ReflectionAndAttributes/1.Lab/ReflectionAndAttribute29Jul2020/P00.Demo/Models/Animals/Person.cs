namespace P00.Demo.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class Person : Animal, IPerson
    {
        private const string DEF_NAME = "Pesho";
        private const int DEF_AGE = 0;
        private const double DEF_WEIGHT = 4.2;

        private double height;
        private readonly ICollection<IAnimal> animals;

        public Person()
            : base(DEF_NAME, DEF_AGE, DEF_WEIGHT)

        {

        }

        public Person(string name, int age, double weight, double height)
            : base(name, age, weight)
        {
            this.Height = height;

            this.animals = new List<IAnimal>();
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be less than or equal to zero!");
                }

                this.height = value;
            }
        }
        public IReadOnlyCollection<IAnimal> Animals 
            => (IReadOnlyCollection<IAnimal>)this.animals;

        public void AddAnimal(IAnimal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException("Animal cannot be null");
            }

            this.animals.Add(animal);
        }
    }
}
