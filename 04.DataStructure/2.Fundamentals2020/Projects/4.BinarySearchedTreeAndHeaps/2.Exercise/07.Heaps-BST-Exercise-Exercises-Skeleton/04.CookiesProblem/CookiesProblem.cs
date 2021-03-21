namespace _04.CookiesProblem
{
    using Wintellect.PowerCollections;

    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            var orderedBag = new OrderedBag<int>(cookies);

            var count = 0;
            while (orderedBag.Count >= 2)
            {
                var leastSweetCooky = orderedBag.RemoveFirst();

                if (leastSweetCooky > k)
                {
                    return count;
                }

                count++;

                var secondleastSweetCooky = orderedBag.RemoveFirst();

                var specialCookie = leastSweetCooky + 2 * secondleastSweetCooky;

                orderedBag.Add(specialCookie);
            }

            return -1;
        }
    }
}
