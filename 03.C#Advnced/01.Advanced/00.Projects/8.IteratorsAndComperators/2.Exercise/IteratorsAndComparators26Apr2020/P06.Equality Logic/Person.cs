using System;
using System.Diagnostics.CodeAnalysis;

namespace P06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo([AllowNull] Person other)
        {
            var comparison = 1;

            if (other != null)
            {
                comparison = name.CompareTo(other.name);

                if (comparison == 0)
                {
                    comparison = age.CompareTo(other.age);
                }
            }

            return comparison;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                return name == person.name && age == person.age;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() + age.GetHashCode();
        }
    }
}
