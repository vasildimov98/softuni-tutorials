namespace P01.SingletonDemo
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("London"));
            var db1 = SingletonDataContainer.Instance;
            Console.WriteLine(db1.GetPopulation("Washington, D.C."));
            var db2 = SingletonDataContainer.Instance;
            var db3 = SingletonDataContainer.Instance;
            var db4 = SingletonDataContainer.Instance;
        }
    }
}
