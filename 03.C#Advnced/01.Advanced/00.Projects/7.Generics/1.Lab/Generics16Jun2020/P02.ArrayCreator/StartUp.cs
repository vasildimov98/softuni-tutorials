namespace GenericArrayCreator
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(10, 33);

            Console.WriteLine(integers[2]);
            Console.WriteLine(strings[2]);
        }
    }
}
