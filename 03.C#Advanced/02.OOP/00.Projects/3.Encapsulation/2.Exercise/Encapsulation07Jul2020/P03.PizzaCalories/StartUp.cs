namespace P03.PizzaCalories
{
    using P03.PizzaCalories.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Run()
        {
            var pizzaArgs = Console
                            .ReadLine()
                            .Split(' ', StringSplitOptions.None)
                            .ToArray();

            var pizzaName = pizzaArgs[1];
            var pizza = new Pizza(pizzaName);

            var doughArgs = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();

            var doughType = doughArgs[0];
            var technique = doughArgs[1];
            var doughWeight = double.Parse(doughArgs[2]);

            var dough = new Dough(doughType, technique, doughWeight);

            pizza.Dough = dough;

            string command;
            while ((command = Console.ReadLine()).ToUpper() != "END")
            {
                var toppingArgs = command
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Skip(1)
               .ToArray();

                var toppingType = toppingArgs[0];
                var toppingWeight = double.Parse(toppingArgs[1]);

                var topping = new Topping(toppingType, toppingWeight);
                pizza.AddTopping(topping);
            }

            Console.WriteLine(pizza);
        }
    }
}
