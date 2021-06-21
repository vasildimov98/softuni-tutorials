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

        public string Name { get; }

        public int Age 
        {
            get
            {
                return this.age;
            }
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
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(String.Format($"Name: {this.Name}, Age: {this.Age}"));

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
