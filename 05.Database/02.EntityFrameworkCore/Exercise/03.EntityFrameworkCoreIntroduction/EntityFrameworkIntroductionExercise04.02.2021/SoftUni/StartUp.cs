namespace SoftUni
{
    using System;
    using System.Text;
    using System.Linq;
    using SoftUni.Data;
    using SoftUni.Models;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new SoftUniContext();

            var result = RemoveTown(dbContext);

            Console.WriteLine(result);
        }

        // Problem 01
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employeeInfo = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                }).ToList();

            foreach (var e in employeeInfo)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 02
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var salaryToLook = 50000;

            var employeesWithSpecificSalary = context
                .Employees
                .Where(e => e.Salary > salaryToLook)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                }).ToList();

            foreach (var e in employeesWithSpecificSalary)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 03
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var departmentName = "Research and Development";

            var employeesResult = context
                .Employees
                .Where(e => e.Department.Name == departmentName)
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                }).ToList();

            foreach (var e in employeesResult)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
            }
           
            return sb.ToString().TrimEnd();
        }

        // Problem 04
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var addressText = "Vitoshka 15";
            var townId = 4;

            var newAddress = new Address
            {
                AddressText = addressText,
                TownId = townId
            };

            var employeeLastName = "Nakov";

            var employee = context.Employees
                .FirstOrDefault(e => e.LastName == employeeLastName);

            employee.Address = newAddress;

            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => new { AddressText = e.Address.AddressText })
                .Take(10)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine(e.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 05
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var startYear = 2001;
            var endYear = 2003;

            var employeesInfo = context.Employees
                .Where(e => e.EmployeesProjects
                             .Any(p => p.Project.StartDate.Year >= startYear
                                    && p.Project.StartDate.Year <= endYear))
                .Select(e => new
                {
                    EmployeeFirstName = e.FirstName,
                    EmployeeLastName = e.LastName,
                    ManageFirstName = e.Manager.FirstName,
                    ManageLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                               .Select(ep => new
                               {
                                   ProjectName = ep.Project.Name,
                                   StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                                   EndDate = ep.Project.EndDate.HasValue ?
                                             ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) :
                                             "not finished"
                               }).ToList()
                }).Take(10)
                .ToList();

            foreach (var e in employeesInfo)
            {
                sb.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - Manager: {e.ManageFirstName} {e.ManageLastName}");

                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 06
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var addressesInfo = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                }).Take(10)
                .ToList();

            foreach (var a in addressesInfo)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 07
        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employeeId = 147;

            var employee147 = context.Employees
                .Where(e => e.EmployeeId == employeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                                .Select(ep => new
                                {
                                    ProjectName = ep.Project.Name
                                })
                                .OrderBy(p => p.ProjectName)
                                .ToList()
                }).FirstOrDefault();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var p in employee147.Projects)
            {
                sb.AppendLine(p.ProjectName);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 08
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employeeCount = 5;

            var departmentInfo = context.Departments
                .Where(d => d.Employees.Count > employeeCount)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                                 .OrderBy(e => e.FirstName)
                                 .ThenBy(e => e.LastName)
                                 .Select(e => new
                                 {
                                     e.FirstName,
                                     e.LastName,
                                     e.JobTitle
                                 }).ToList()
                }).ToList();

            foreach (var d in departmentInfo)
            {
                sb.AppendLine($"{d.DepartmentName} – {d.ManagerFirstName} {d.ManagerLastName}");

                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 09
        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projectsInfo = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                }).Take(10)
                .ToList();

            foreach (var p in projectsInfo.OrderBy(p => p.Name))
            {
                sb
                    .AppendLine(p.Name)
                    .AppendLine(p.Description)
                    .AppendLine(p.StartDate);
            }

            return sb.ToString().TrimEnd();
        }

        // Project 10
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var departmnets = new[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                .Where(e => departmnets.Contains(e.Department.Name));

            var increaseRate = 1.12M;
            foreach (var e in employees)
            {
                e.Salary *= increaseRate;
            }

            context.SaveChanges();

            var employeesInfo = context.Employees
                .Where(e => departmnets.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new 
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                }).ToList();

            foreach (var e in employeesInfo)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        // Project 11
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var startingWith = "Sa";

            var employeesStartingWithSa = context.Employees
                .Where(e => e.FirstName.StartsWith(startingWith))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                }).ToList();

            foreach (var e in employeesStartingWithSa)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary})");
            }

            return sb.ToString().TrimEnd();
        }

        // Project 12
        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projectId = 2;

            var project = context.Projects.Find(projectId);

            var employeeWithProjectIdTwo = context.EmployeesProjects
                .Where(ep => ep.ProjectId == projectId);

            context.EmployeesProjects.RemoveRange(employeeWithProjectIdTwo);

            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects
                .Select(p => new
                {
                    p.Name
                }).Take(10)
                .ToList();

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
            }

            return sb.ToString().TrimEnd();
        }

        // Project 13
        public static string RemoveTown(SoftUniContext context)
        {
            var townToDeleteName = "Seattle";

            var townToDelete = context.Towns
                .FirstOrDefault(t => t.Name == townToDeleteName);

            var addressesToDelete = context.Addresses
                .Where(a => a.TownId == townToDelete.TownId);

            var addressesDeletedCount = addressesToDelete.Count();

            var employeesWithAddressesToDelete = context.Employees
                .Where(e => addressesToDelete.Any(ad => ad.AddressId == e.AddressId));

            foreach (var e in employeesWithAddressesToDelete)
            {
                e.AddressId = null;
            }

            foreach (var a in addressesToDelete)
            {
                context.Addresses.Remove(a);
            }

            context.Towns.Remove(townToDelete);

            return $"{addressesDeletedCount} addresses in Seattle were deleted";
        }
    }
}
