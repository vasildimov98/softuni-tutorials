namespace P02.FacadeDemo
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var car = new CarBuilderFacade()
                .Info
                  .WithType("BMW")
                  .WithColor("Black")
                  .WithNumberOfDoors(4)
                .Built
                  .InCity("Leipzig")
                  .AtAddress("Some DEUTSCHLAND ADDRESS")
                .Build();

            Console.WriteLine(car);
        }
    }
}
