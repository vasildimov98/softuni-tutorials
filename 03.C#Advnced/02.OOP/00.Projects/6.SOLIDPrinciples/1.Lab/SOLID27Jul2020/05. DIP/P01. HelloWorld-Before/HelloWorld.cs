namespace P01._HelloWorld
{
    using System;

    public class HelloWorld
    {
        private readonly DateTime dateTime;

        // Constructor Injection
        public HelloWorld(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public string Greeting(string name)
        {
            if (this.dateTime.Hour < 12)
            {
                return "Good morning, " + name;
            }

            if (this.dateTime.Hour < 18)
            {
                return "Good afternoon, " + name;
            }

            return "Good evening, " + name;
        }
    }
}
