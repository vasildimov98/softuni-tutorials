namespace Zoo
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var lizard = new Lizard("Pesho");

            Console.WriteLine(lizard.Name);
        }
    }
}