namespace P04.BestLecturesSchedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<Lecture> lectures;
        private static readonly List<Lecture> schedule = new List<Lecture>();
        static void Main()
        {
            lectures = ReadInput();
            CreateSchedule();
            PrintSchedule();
        }

        private static void PrintSchedule()
        {
            Console.WriteLine($"Lectures ({schedule.Count}):");
            foreach (var lecture in schedule)
                Console.WriteLine($"{lecture.StartTime}-{lecture.FinishTime} -> {lecture.Name}");
        }

        private static void CreateSchedule()
        {
            var lastLecture = lectures[0];
            schedule.Add(lastLecture);
            for (int i = 1; i < lectures.Count; i++)
            {
                var currLecture = lectures[i];

                if (currLecture.StartTime >= lastLecture.FinishTime)
                {
                    schedule.Add(currLecture);
                    lastLecture = currLecture;
                }
            }
        }

        private static List<Lecture> ReadInput()
        {
            var countOfLectures = int.Parse(
                Console
                .ReadLine()
                .Split()[1]);

            var lecturesToReturn = new List<Lecture>();

            for (int i = 0; i < countOfLectures; i++)
            {
                var lectureArgs = Console
                    .ReadLine()
                    .Split(new char[] { ' ', '-', ':'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var lectureName = lectureArgs[0];
                var lectureStartTime = int.Parse(lectureArgs[1]);
                var lectureFinishTime = int.Parse(lectureArgs[2]);

                var lecture = new Lecture(lectureName, lectureStartTime, lectureFinishTime);

                lecturesToReturn.Add(lecture);
            }

            return lecturesToReturn
                .OrderBy(l => l.FinishTime)
                .ToList();
        }
    }

    internal class Lecture
    {
        public Lecture(string name, int startTime, int finishTime)
        {
            this.Name = name;
            this.StartTime = startTime;
            this.FinishTime = finishTime;
        }

        public string Name { get; set; }
        public int StartTime { get; set; }
        public int FinishTime { get; set; }
    }
}
