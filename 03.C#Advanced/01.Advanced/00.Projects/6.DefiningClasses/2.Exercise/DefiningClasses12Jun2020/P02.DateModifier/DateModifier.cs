namespace P02.DateModifier
{
    using System;
    using System.Linq;

    public static class DateModifier
    {
        public static int CalDiffBetweenTwoDates(string first, string second)
        {
            var firstDateArgs = first
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var year1 = int.Parse(firstDateArgs[0]);
            var month1 = int.Parse(firstDateArgs[1]);
            var day1 = int.Parse(firstDateArgs[2]);

            var secondDateArgs = second
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var year2 = int.Parse(secondDateArgs[0]);
            var month2 = int.Parse(secondDateArgs[1]);
            var day2 = int.Parse(secondDateArgs[2]);

            var date1 = new DateTime(year1, month1, day1);
            var date2 = new DateTime(year2, month2, day2);

            return Math.Abs((date1 - date2).Days);
        }
    }
}
