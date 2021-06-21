namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main()
        {
            var randomList = new RandomList();

            randomList.Add("Test1");
            randomList.Add("Test2");
            randomList.Add("Test3");
            randomList.Add("Test4");

            for (int i = 0; i < 4; i++)
            {
                System.Console.WriteLine(randomList.RandomString());
            }
        }
    }
}
