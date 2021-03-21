namespace P01._HelloWorld_After
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new HelloWorld(new DateTime(1991, 2, 3, 10, 2, 3)).Greeting("Ivan"));
        }
    }
}
