namespace P04.PizzaCalories
{
    using System;
    using System.Linq;

    using P04.PizzaCalories.Ingredients;
    using P04.PizzaCalories.Module;
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var pizza = GetPizza();
                var dough = GetDough();
                pizza.Dough = dough;
                GetAllToppings(pizza);
                Console.WriteLine(pizza.ToString());
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }
        }

        private static void GetAllToppings(Pizza pizza)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var toppingArg = command
               .Split(' ', StringSplitOptions.None)
               .ToArray();

                var type = toppingArg[1];
                var toppingWeight = double.Parse(toppingArg[2]);

                var topping = new Topping(type, toppingWeight);

                pizza.AddTopping(topping);
            }
        }

        private static Dough GetDough()
        {
            var doughArg = Console.ReadLine()
                .Split(' ', StringSplitOptions.None)
                .ToArray();

            var flourType = doughArg[1];
            var backingTechnique = doughArg[2];
            var doughWeight = double.Parse(doughArg[3]);

            return new Dough(flourType, backingTechnique, doughWeight);
        }

        private static Pizza GetPizza()
        {
            var pizzaArg = Console.ReadLine()
                .Split(' ', StringSplitOptions.None)
                .ToArray();

            var pizzaName = pizzaArg[1];
            var pizza = new Pizza(pizzaName);
            return pizza;
        }
    }
}
