namespace P03.PizzaCalories.Contracts
{
    public static class ExceptionMessages
    {
        public const string InvalidTypeOfDough = "Invalid type of dough.";
        public const string InvalidTypeOfTopping = "Cannot place {0} on top of your pizza.";
        public const string InvalidTypeOfPizza = "Pizza name should be between 1 and 15 symbols.";
        public const string InvalidRangeOfWeightOfDough = "Dough weight should be in the range [1..200].";
        public const string InvalidRangeOfWeightOfTopping = "{0} weight should be in the range [1..50].";
        public const string InvalidNumberToppings = "Number of toppings should be in range [0..10].";
    }
}
