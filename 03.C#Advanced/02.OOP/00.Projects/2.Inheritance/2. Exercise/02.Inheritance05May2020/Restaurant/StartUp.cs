using Restaurant.Foods;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main()
        {
            var food = new Product("Something", 12);

            System.Console.WriteLine(food.Price);
        }
    }
}