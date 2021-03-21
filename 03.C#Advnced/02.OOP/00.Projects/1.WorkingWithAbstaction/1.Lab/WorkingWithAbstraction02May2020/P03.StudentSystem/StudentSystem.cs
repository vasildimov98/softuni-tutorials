using System;
using System.Collections.Generic;
using System.Text;

namespace P03.StudentSystem
{
    public class StudentSystem
    { 
        public Dictionary<string, Student> Students { get; } = new Dictionary<string, Student>();
        public void AddStudent(string name, int age, double grade)
        {
            if (!Students.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                Students[name] = student;
            }
        }

        public string GetDetails(string[] args)
        {
            var details = new StringBuilder();
            var name = args[0];
            if (Students.ContainsKey(name))
            {
                var student = Students[name];
                details.Append($"{student.Name} is {student.Age} years old.");

                if (student.Grade >= 5.00)
                {
                    details.Append(" Excellent student.");
                }
                else if (student.Grade < 5.00 && student.Grade >= 3.50)
                {
                    details.Append(" Average student.");
                }
                else
                {
                    details.Append(" Very nice person.");
                }
            }

            return details.ToString().TrimEnd();
        }
    }
}
