namespace CustomStack
{
    public class StartUp
    {
        public static void Main()
        {
            var stackOfString = new StackOfStrings();

            System.Console.WriteLine(stackOfString.IsEmpty());

            stackOfString.AddRange(new[] { "Test1", "Test2", "Test3", "Test4" });

            System.Console.WriteLine(stackOfString.IsEmpty());

            foreach (var item in stackOfString)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
