namespace MiniORM.App
{
    using System.Linq;
    using MiniORM.App.Data;
    using MiniORM.App.Data.Entities;

    public class StartUp
    {
        static void Main()
        {
            var connectionString = "Server=.;Database=MiniORM;Integrated Security=True";

            var context = new SoftUniDbContextClass(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "George",
                MiddleName = "V",
                LastName = "Dimov",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();
            employee.MiddleName = "Vladimirov";

            context.SaveChanges();
        }
    }
}
