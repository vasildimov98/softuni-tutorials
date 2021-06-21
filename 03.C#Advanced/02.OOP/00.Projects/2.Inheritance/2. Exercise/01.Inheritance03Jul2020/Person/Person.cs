namespace Person
{
    using System;
    using System.Text;

    public class Person
    {
        private int age;

        public Person(string name, int age)
        {
           this.Name = name;
           this.Age = age;
        }

        public string Name { get; private set; }
        public int Age
        {
            get => this.age;
            protected set
            {
                if (value >= 0)
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
