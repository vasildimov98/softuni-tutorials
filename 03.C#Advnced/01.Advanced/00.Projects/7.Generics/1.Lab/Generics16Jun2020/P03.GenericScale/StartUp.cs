namespace GenericScale
{
    public class StartUp
    {
        public static void Main()
        {
            var left = 2;
            var right = 200000000;

            var equalityScale = new EqualityScale<int>(left, right);

            var areEqual = equalityScale.AreEqual();

            System.Console.WriteLine(areEqual);
        }
    }
}
