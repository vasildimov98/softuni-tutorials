using System.Collections.Generic;

namespace InterfaceAndAbstractionDemo
{
    public class StartUp
    {
        public static void Main()
        {
            var dog = new Dog("Sharo", 4);

            dog.Sleep();
            (dog as IWalkable).Walk();
        }
    }
}
