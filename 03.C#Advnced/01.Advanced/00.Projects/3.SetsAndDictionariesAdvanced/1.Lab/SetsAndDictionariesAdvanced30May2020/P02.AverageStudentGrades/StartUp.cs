namespace P02.AverageStudentGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static Dictionary<string, List<decimal>> gradesBook;
        public static void Main()
        {
            gradesBook = new Dictionary<string, List<decimal>>();

            var numberOfCommands = int.Parse(Console.ReadLine());

            FillGradeBook(numberOfCommands);
            PrintResult();
        }

        private static void PrintResult()
        {
            foreach (var (studentName, grades) in gradesBook)
            {
                Console.WriteLine($"{studentName} -> {string.Join(" ", grades.Select(gr => gr.ToString("F2")))} (avg: {grades.Average():F2})");
            }
        }

        private static void FillGradeBook(int numberOfCommands)
        {
            for (int i = 0; i < numberOfCommands; i++)
            {
                var studentInfoArgs = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var studentName = studentInfoArgs[0];
                var studentGrade = decimal.Parse(studentInfoArgs[1]);

                if (!gradesBook.ContainsKey(studentName))
                {
                    gradesBook[studentName] = new List<decimal>();
                }

                gradesBook[studentName].Add(studentGrade);
            }
        }
    }
}
