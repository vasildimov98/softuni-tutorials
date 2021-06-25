namespace MiniORM.App.Data
{
    using Entities;
    public class SoftUniDbContextClass : DbContext
    {
        public SoftUniDbContextClass(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeesProjects { get; set; }
    }
}
