namespace MiniORM.App
{
    using MiniORM.App.Data;
    using MiniORM.App.Data.Entitites;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var connectionText = "Server=.;Integrated Security=True;Database=MiniORM";

            var context = new SoftUniDbContext(connectionText);

            var employee = context.Employees
                 .Where(e => e.FirstName == "Gosho")
                 .FirstOrDefault();

            employee.MiddleName = "Georgiev1";

            context.SaveChanges();
        }
    }
}
