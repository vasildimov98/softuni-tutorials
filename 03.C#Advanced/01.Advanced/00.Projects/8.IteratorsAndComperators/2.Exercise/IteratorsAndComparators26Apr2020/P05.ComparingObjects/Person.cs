using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace P05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;
        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo([AllowNull] Person other)
        {
            var result = 1;

            if (other != null)
            {
                result = this.name.CompareTo(other.name);

                if (result == 0)
                {
                    result = this.age.CompareTo(other.age);
                }

                if (result == 0)
                {
                    result = this.town.CompareTo(other.town);
                }
            }

            return result;
        }
    }
}
