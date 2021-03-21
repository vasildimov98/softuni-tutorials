
namespace P01._HelloWorld_Before
{
    using System;

    using P01._HelloWorld;

    class Program
    {
        static void Main(string[] args)
        {
            var helloWorld = new HelloWorld();

            Console.WriteLine(helloWorld.Greeting("Ivan"));
        }
    }
}
