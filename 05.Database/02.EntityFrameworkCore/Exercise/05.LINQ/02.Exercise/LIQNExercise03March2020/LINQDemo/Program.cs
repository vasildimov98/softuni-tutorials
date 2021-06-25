namespace LINQDemo
{
    using LINQDemo.Data;
    using LINQDemo.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    internal class EmployeeViewModel
    {
        public string FullName { get; set; }

        public int WorkingYears { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{this.FullName} {this.Salary} {this.WorkingYears}";
        }
    }

    public class Program
    {
        static void Main()
        {
            using var context = new SoftuniContext();

            var employees = context.Employees
                .Where(x => x.Salary >= 50000)
                .Select(x => new
                {
                    x.EmployeeId,
                    EmployeeInfo = context.GetEmployeeInfo(x.EmployeeId)
                })
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, employees));
        }

        private static Expression<Func<Employee, EmployeeViewModel>> MapEmployeeToViewModel()
        {
            return x => new EmployeeViewModel
            {
                FullName = $"{x.FirstName} {x.LastName}",
                Salary = x.Salary,
                WorkingYears = EF.Functions.DateDiffYear(x.HireDate, DateTime.Parse("2014-03-04"))
            };
        }
    }
}
