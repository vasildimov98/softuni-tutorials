using System;
using System.Collections.Generic;

namespace _05._Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Hometown { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";

            List<Student> students = new List<Student>();
           

            while ((command = Console.ReadLine()) != "end")
            {
                string[] data = command
                    .Split();

                string firstName = data[0];
                string lastName = data[1];
                string age = data[2];
                string hometown = data[3];

                Student student = new Student();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.Hometown = hometown;

                students.Add(student);
            }

            command = Console.ReadLine();
            foreach (var student in students)
            {
                if (student.Hometown == command)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
}
