namespace SoftUni
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;
    using SoftUni.Models;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new SoftUniContext();

            var result = RemoveTown(dbContext);

            Console.WriteLine(result);
        }

        //Problem 01
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employeeInfo = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => $"{e.FirstName} {e.LastName}{(e.MiddleName == null ? string.Empty : $" {e.MiddleName}")} {e.JobTitle} {e.Salary:F2}")
                .ToList();

            return string.Join(Environment.NewLine, employeeInfo);
        }

        //Problem 02
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employeesOutput = context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => $"{e.FirstName} - {e.Salary:F2}")
                .ToList();

            return string.Join(Environment.NewLine, employeesOutput);
        }

        //Problem 03
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var output = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => $"{e.FirstName} {e.LastName} from Research and Development - ${e.Salary:F2}")
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        //Problem 04 
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");

            if (employee != null)
                employee.Address = newAddress;

            context.Addresses.Add(newAddress);

            context.SaveChanges();

            var output = context.Employees
                .OrderByDescending(e => e.Address.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        //Problem 05
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var output = context.Employees
                .Where(e => e.EmployeesProjects.Any(ep
                    => ep.Project.StartDate.Year >= 2001
                    && ep.Project.StartDate.Year <= 2003))
                .Select(e => $"{$"{e.FirstName} {e.LastName} - Manager: {e.Manager.FirstName} {e.Manager.LastName}"}{Environment.NewLine}{(string.Join(Environment.NewLine, e.EmployeesProjects.Select(ep => $"--{ep.Project.Name} - {ep.Project.StartDate:M/d/yyyy h:mm:ss tt} - {(ep.Project.EndDate == null ? "not finished" : ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt"))}")))}"
                )
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        //Problem 06
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var output = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a => $"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees")
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        //Problem 07
        public static string GetEmployee147(SoftUniContext context)
        {
            var employeeById = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    EmployeeProjectName = e.EmployeesProjects
                        .Select(ep => ep.Project.Name)
                })
                .FirstOrDefault();

            var sb = new StringBuilder();

            sb
                .AppendLine($"{employeeById.FirstName} {employeeById.LastName} - {employeeById.JobTitle}")
                .AppendLine(string.Join(Environment.NewLine, employeeById.EmployeeProjectName.OrderBy(n => n)));

            return sb.ToString().TrimEnd();
        }

        //Problem 08
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departmentWithMoreThanFiveEmployees = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DeparmentWithManager = $"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}",
                    EmployeesWithJobTitles = string.Join(Environment.NewLine, d.Employees
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle}"))
                })
                .ToList();

            var output = new StringBuilder();

            foreach (var departmetInfo in departmentWithMoreThanFiveEmployees)
            {
                output
                    .AppendLine(departmetInfo.DeparmentWithManager)
                    .AppendLine(departmetInfo.EmployeesWithJobTitles);
            }

            return output.ToString().TrimEnd();
        }

        //Problem 09
        public static string GetLatestProjects(SoftUniContext context)
        {
            var lastTenStartedProjects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .Take(10)
                .OrderBy(p => p.Name)
                .ToList();

            var output = new StringBuilder();

            foreach (var project in lastTenStartedProjects)
            {
                output
                    .AppendLine(project.Name)
                    .AppendLine(project.Description)
                    .AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return output.ToString().TrimEnd();
        }

        //Problem 10
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var deparmentsToSearch = new[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employeesToIncreaseSalary = context.Employees
                .Where(e => deparmentsToSearch.Contains(e.Department.Name))
                .ToList();

            employeesToIncreaseSalary.ForEach(e => e.Salary *= 1.12M);

            context.SaveChanges();

            return string.Join(Environment.NewLine, employeesToIncreaseSalary
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => $"{e.FirstName} {e.LastName} (${e.Salary:F2})"));
        }

        //Problem 11
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var output = context.Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})")
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        //Problem 12 
        public static string DeleteProjectById(SoftUniContext context)
        {
            context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList()
                .ForEach(e => context.Remove(e));

            var projectById = context.Projects.Find(2);

            context.Projects.Remove(projectById);

            context.SaveChanges();

            var output = context.Projects
                .Select(p => p.Name)
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        //Problem 13
        public static string RemoveTown(SoftUniContext context)
        {
            var seattle = "seattle";

            var townToDelete = context.Towns
                .Include(t => t.Addresses)
                .FirstOrDefault(t => t.Name.ToLower() == seattle);

            if (townToDelete == null)
                return "Town is already deleted or it doesn't exists";

            var addressesIdsToDelete = townToDelete.Addresses
                .Select(a => a.AddressId)
                .ToHashSet();

            var employeesByAddress = context.Employees
                .Where(e => e.AddressId.HasValue && addressesIdsToDelete.Contains(e.AddressId.Value))
                .ToList();

            foreach (var empl in employeesByAddress)
            {
                empl.AddressId = null;
            }

            foreach (var addressId in addressesIdsToDelete)
            {
                var address = townToDelete.Addresses.FirstOrDefault(a => a.AddressId == addressId);

                context.Addresses.Remove(address);
            }

            context.Towns.Remove(townToDelete);

            context.SaveChanges();

            var output = $"{addressesIdsToDelete.Count} addresses in Seattle were deleted";

            return output;
        }
    }
}
