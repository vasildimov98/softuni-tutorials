using System;
using System.Linq;
namespace P05._Date_Modifier
{
    class DateModifier
    {
        public int DifferenceBetweenTwoDates(string date1, string date2)
        {
            var date1Arg = date1
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var year1 = date1Arg[0];
            var month1 = date1Arg[1];
            var day1 = date1Arg[2];

            var dateOne = new DateTime(year1, month1, day1);

            var date2Arg = date2
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            var year2 = date2Arg[0];
            var month2 = date2Arg[1];
            var day2 = date2Arg[2];

            var dateTwo = new DateTime(year2, month2, day2);

            return Math.Abs((dateOne - dateTwo).Days);
        }
    }
}
