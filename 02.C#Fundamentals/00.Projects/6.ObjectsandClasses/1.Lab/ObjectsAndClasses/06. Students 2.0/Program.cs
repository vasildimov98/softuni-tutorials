using System;
using System.Collections.Generic;

namespace _06._Students_2._0
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

                if (IsStudentExising(students, firstName, lastName))
                {
                    Student student = GetStudent(students, firstName, lastName);

                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.Hometown = hometown;
                }
                else
                {
                    Student student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        Hometown = hometown
                    };
                    students.Add(student);
                }
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

        static bool IsStudentExising(List<Student> students, string firstName, string lastName)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }

        static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;

            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;
        }
    }
}
