namespace P00.CodeFirstDemo
{
    using Microsoft.EntityFrameworkCore;
    using P00.CodeFirstDemo.Modules;
    class Program
    {
        static void Main()
        {
            var context = new RecipesDbContext();
            context.Database.Migrate();
        }
    }
}
