namespace P00.DatabaseFirstDemo
{
    using Microsoft.EntityFrameworkCore;

    using P00.Demo.Modules;

    class Program
    {
        static void Main()
        {
            var optionBuilder = new DbContextOptionsBuilder<MusicXContext>();
            optionBuilder.UseSqlServer("Server=.;Database=MusicX2;Integrated Security=true;");

            var context = new MusicXContext(optionBuilder.Options);
            context.Database.EnsureCreated();

            //var artists = context.Songs
            //    .Where(s => s.SongArtists.Count() > 1)
            //    .Select(a =>
            //    new 
            //    {
            //        Name = a.Name
            //    })
            //    .ToList();

            //foreach (var artist in artists)
            //{
            //    Console.WriteLine(artist.Name);
            //}
        }
    }
}
