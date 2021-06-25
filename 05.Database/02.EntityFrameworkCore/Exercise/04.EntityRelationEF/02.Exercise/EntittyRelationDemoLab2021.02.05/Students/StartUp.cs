namespace Students
{
    using Students.Data;
    using Students.Models;

    public class StartUp
    {
        static void Main()
        {
            var context = new UnivercityContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Students.Add(new Student
            {
                StudentName = "Vasil",
                FacultyNumber = "170023",
                Address = new Address
                {
                    AddressText = "Sofia",
                    Town = new Town
                    {
                        Name = "Sofia"
                    }
                }
            });

            context.SaveChanges();
        }
    }
}
