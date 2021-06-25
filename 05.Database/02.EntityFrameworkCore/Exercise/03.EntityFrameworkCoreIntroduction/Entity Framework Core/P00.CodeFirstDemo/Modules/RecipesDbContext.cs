namespace P00.CodeFirstDemo.Modules
{
    using Microsoft.EntityFrameworkCore;
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext()
        {
        }

        public RecipesDbContext(DbContextOptions<RecipesDbContext> options)
            :   base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=.;Database=Recipes;Integrated Security=true");
        }
    }
}
