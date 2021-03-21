namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;

    public class RandomList : List<string>
    {
        private Random rnd = new Random();
        public string RandomString()
        {
            var randomString = string.Empty;
            var randomIndex = rnd.Next(0, base.Count);

            randomString = base[randomIndex];

            base.RemoveAt(randomIndex);

            return randomString;
        }
    }
}
