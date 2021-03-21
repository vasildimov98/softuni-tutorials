namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;

    public class Dog : IComparable<Dog>
    {
        public Dog(string id, string name, Breed breed, int age, int vaccines)
        {
            this.Id = id;
            this.Name = name;
            this.Breed = breed;
            this.Age = age;
            this.Vaccines = vaccines;
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public Breed Breed { get; set; }

        public int Age { get; set; }

        public int Vaccines { get; set; }

        public Owner Owner { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Dog;

            return this.Id == other.Id;
        }

        public int CompareTo(Dog other)
            => this.Name.CompareTo(other.Name);

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<string>.Default.GetHashCode(Id);
        }
    }
}