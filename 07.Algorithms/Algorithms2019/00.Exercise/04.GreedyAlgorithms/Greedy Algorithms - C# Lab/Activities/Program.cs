namespace Activities
{
    using System;
    using System.Collections.Generic;

    class Activity
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var startTime = new[] { 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12 };
            var endTime = new[] { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            var activities = new List<Activity>();
            for (int i = 0; i < startTime.Length; i++)
            {
                activities.Add(new Activity
                {
                    StartTime = startTime[i],
                    EndTime = endTime[i]
                });
            }

            var result = new List<Activity>();

            var currOptionalActivity = activities[1];
            Console.WriteLine($"Start Time: {currOptionalActivity.StartTime} - Finish Time: {currOptionalActivity.EndTime}");
            for (int i = 1; i < activities.Count; i++)
            {
                var currActivity = activities[i];
                if (currActivity.StartTime >= currOptionalActivity.EndTime)
                {
                    currOptionalActivity = currActivity;
                    Console.WriteLine($"Start Time: {currOptionalActivity.StartTime} - Finish Time: {currOptionalActivity.EndTime}");
                }
            }
        }
    }
}
