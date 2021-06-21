using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main()
        {
            Console.WriteLine(new Scale<int>(2, 3).AreEqual());
        }
    }
}
