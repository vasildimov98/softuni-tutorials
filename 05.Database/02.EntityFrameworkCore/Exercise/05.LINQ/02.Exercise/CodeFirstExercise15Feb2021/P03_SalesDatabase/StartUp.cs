namespace P03_SalesDatabase
{
    using P03_SalesDatabase.Data;
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new SalesContext();
        }
    }
}
