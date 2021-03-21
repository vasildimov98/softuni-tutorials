using System;

namespace Zoo
{
    public abstract class Animal
    {
        private string name;
        public Animal(string name)
        {
            this.Name = name;
        }

        public string Name { get;}
    }
}
