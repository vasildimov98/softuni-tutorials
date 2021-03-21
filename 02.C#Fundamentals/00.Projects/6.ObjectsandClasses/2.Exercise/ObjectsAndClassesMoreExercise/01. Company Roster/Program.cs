using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Company_Roster
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console
                    .ReadLine()
                    .Split();

                string name = data[0];
                double salary = double.Parse(data[1]);
                string department = data[2];

                Employee employee = new Employee(name, salary, department);

                employees.Add(employee);
            }

            List<Employee> employees1 = new List<Employee>();
            List<Employee> maxEmployess = new List<Employee>();
            double maxAverageSalary = 0;
            string maxDepartment = "";
            for (int i = 0; i < employees.Count; i++)
            {
                string currDepartment = employees[i].Department;

                employees1 = employees.Where(a => a.Department == currDepartment).ToList();
                double averageSalary = 0;

                for (int j = 0; j < employees1.Count; j++)
                {
                    averageSalary += employees1[j].Salary;
                }

                averageSalary /= employees1.Count;
                if (averageSalary > maxAverageSalary)
                {
                    maxAverageSalary = averageSalary;
                    maxDepartment = currDepartment;
                    maxEmployess = new List<Employee>();
                    for (int index = 0; index < employees1.Count; index++)
                    {
                        maxEmployess.Add(employees1[index]);
                    }
                }
            }

            Console.WriteLine($"Highest Average Salary: {maxDepartment}");

            maxEmployess = maxEmployess.OrderByDescending(a => a.Salary).ToList();

            foreach (var employee in maxEmployess)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
            }
        }
    }

    class Employee
    {
        public Employee(string name, double salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
}
