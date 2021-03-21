namespace Telephony
{
    using System;
    using System.Linq;
    using Telephony.Models;

    public class StartUp
    {
        static void Main()
        {
            var smartPhone = new Smartphone();
            var stationaryPhone = new StationaryPhone();

            var numbersToCall = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var sitesToBrowse = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            CallAllNumbers(smartPhone, stationaryPhone, numbersToCall);

            BrowseAllSites(smartPhone, sitesToBrowse);
        }

        private static void BrowseAllSites(Smartphone smartPhone, string[] sitesToBrowse)
        {
            foreach (var site in sitesToBrowse)
            {
                Console.WriteLine(smartPhone.Browse(site));
            }
        }

        private static void CallAllNumbers(Smartphone smartPhone, StationaryPhone stationaryPhone, string[] numbersToCall)
        {
            const int STATIONARY_PHONE_NUMBER = 7;

            foreach (var number in numbersToCall)
            {
                if (number.Length == STATIONARY_PHONE_NUMBER)
                {
                    Console.WriteLine(stationaryPhone.Call(number));
                }
                else
                {
                    Console.WriteLine(smartPhone.Call(number));
                }
            }
        }
    }
}
