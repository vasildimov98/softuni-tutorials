namespace P00.InheritanceDemo
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        public static void Main()
        {
            var person = new Person("Pesho", "Vitosha");

            var employee = new Employee("George", "Vitosha", "SoftUni");

            var student = new Student("Stoyan", "Vitosha", "SoftUni");

            var list = new List<string>();

            person.Sleep();
            employee.Sleep();
            student.Sleep();

            var person1 = new Person();
            var employee1 = new Employee();

            var collegeStudent = new CollegeStudent("Petyo", "Vitosha", "Harward");

            collegeStudent.Study();

            collegeStudent.Sleep();

           Console.WriteLine(person.ToString());
           Console.WriteLine(employee.ToString());
           Console.WriteLine(collegeStudent.ToString());
        }
    }
}
