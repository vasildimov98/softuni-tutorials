﻿namespace Zoo
{
    public class Reptile : Animal
    {
        public Reptile(string name)
            : base(name)
        {
        }
        public new string Name { get; }
    }
}
