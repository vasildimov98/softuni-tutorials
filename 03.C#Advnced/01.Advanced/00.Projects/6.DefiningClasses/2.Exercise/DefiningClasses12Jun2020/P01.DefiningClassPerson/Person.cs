using System.ComponentModel.DataAnnotations;

namespace DefiningClasses
{
    public class Person
    {
        private const string DEF_NAME = "No name";
        private int DEF_AGE = 1;

        private string name;
        private int age;

        public Person()
        {
            this.Name = DEF_NAME;
            this.Age = DEF_AGE;
        }

        public Person(int age)
            : this()
        {
            this.Age = age;
        }

        public Person(string name, int age)
            : this(age)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public int Age
        {
            get => this.age;
            set => this.age = value;
        }
    }
}
