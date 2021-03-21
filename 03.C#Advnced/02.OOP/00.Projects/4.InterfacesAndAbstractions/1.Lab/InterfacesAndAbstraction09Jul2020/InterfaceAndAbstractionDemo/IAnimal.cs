using System.Runtime.CompilerServices;

namespace InterfaceAndAbstractionDemo
{
    using System;
    public interface IAnimal
    {
        string Name { get; }
        int Age { get; }

        void Sleep();
    }
}
