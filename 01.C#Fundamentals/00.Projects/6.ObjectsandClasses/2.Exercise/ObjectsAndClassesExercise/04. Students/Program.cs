using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<Information> students = new List<Information>();

            GetAllLists(num, students);

            students = students.OrderByDescending(g => g.Grade).ToList();

            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
            }
        }

        private static void GetAllLists(int num, List<Information> students)
        {
            for (int i = 0; i < num; i++)
            {
                List<string> data = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                string firstName = data[0];
                string lastName = data[1];
                double grade = double.Parse(data[2]);

                Information information = new Information(firstName, lastName, grade);

                students.Add(information);

                Student student = new Student(students);
            }
        }
    }

    class Information
    {
        public Information(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }

    class Student
    {
        public Student(List<Information> students)
        {
            Students = students;
        }

        public List<Information> Students { get; set; }
    }
}
