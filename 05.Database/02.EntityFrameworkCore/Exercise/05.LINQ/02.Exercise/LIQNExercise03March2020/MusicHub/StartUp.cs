namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //Test your solutions here
            //var albumsByProducer = ExportAlbumsInfo(context, 9);

            var songsAboveDuration = ExportSongsAboveDuration(context, 4);

            Console.WriteLine(songsAboveDuration);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsByProducer = context.Producers
                .Include(x => x.Albums)
                .ThenInclude(x => x.Songs)
                .ThenInclude(x => x.Writer)
                .FirstOrDefault(x => x.Id == producerId)
                .Albums
                .Select(x => new
                 {
                     x.Name,
                     x.ReleaseDate,
                     ProducerName = x.Producer.Name,
                     Songs = x.Songs
                        .Select(y => new
                        {
                            y.Name,
                            y.Price,
                            WriterName = y.Writer.Name
                        })
                        .OrderByDescending(y => y.Name)
                        .ThenBy(y => y.WriterName)
                        .ToList(),
                     AlbumPrice = x.Price
                 })
                .OrderByDescending(x => x.AlbumPrice)
                .ToList();

            var sb = new StringBuilder();

            foreach (var album in albumsByProducer)
            {
                sb
                    .AppendLine($"-AlbumName: {album.Name}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate:MM/dd/yyyy}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");

                var songNumber = 1;
                foreach (var song in album.Songs)
                {
                    sb
                        .AppendLine($"---#{songNumber++}")
                        .AppendLine($"---SongName: {song.Name}")
                        .AppendLine($"---Price: {song.Price:F2}")
                        .AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songsAboveDuration = context.Songs
                .Include(x => x.Writer)
                .Include(x => x.SongPerformers)
                .ThenInclude(x => x.Performer)
                .Include(x => x.Album)
                .ThenInclude(x => x.Producer)
                .AsEnumerable()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new
                {
                    x.Name,
                    Writer = x.Writer.Name,
                    Performer = x.SongPerformers
                        .Select(x => $"{x.Performer.FirstName + " " + x.Performer.LastName}")
                        .FirstOrDefault(),
                    AlbumProducer = x.Album.Producer.Name,
                    x.Duration
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Writer)
                .ThenBy(x => x.Performer)
                .ToList();

            var sb = new StringBuilder();

            var songCounter = 1;
            foreach (var song in songsAboveDuration)
            {
                sb
                  .AppendLine($"-Song #{songCounter++}")
                  .AppendLine($"---SongName: {song.Name}")
                  .AppendLine($"---Writer: {song.Writer}")
                  .AppendLine($"---Performer: {song.Performer}")
                  .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                  .AppendLine($"---Duration: {song.Duration:c}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
