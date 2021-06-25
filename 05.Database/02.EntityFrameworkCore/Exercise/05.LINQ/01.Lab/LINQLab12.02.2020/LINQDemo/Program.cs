namespace LINQDemo
{
    using System;
    using AutoMapper;
    using System.Linq;
    using Newtonsoft.Json;
    using Z.EntityFramework.Plus;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using LINQDemo.Models;
    using AutoMapper.QueryableExtensions;

    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var dbContext = new MusicXContext();

            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MusicProfile>());

            var mapper = cfg.CreateMapper();

            var source = dbContext.Artists
                .Skip(23)
                //.Select(a => new ArtistDTO 
                //{
                //    Name = a.Name,
                //    SongCount = a.SongArtists.Count()
                //})
                .ProjectTo<ArtistDTO>(cfg)
                .FirstOrDefault();

            var artistDTO = new ArtistDTO
            {
                Name = "Bon Jovi",
                SongCount = 23
            };

            var artist = mapper.Map<ArtistDTO, Artist>(artistDTO);

            PrintAsJSON(artist);
        }

        private static void PrintAsJSON(object artists)
        {
            Console.WriteLine(JsonConvert.SerializeObject(artists, Formatting.Indented)); 
        }
    }

    internal class SongDTO
    {
        public string Name { get; set; }
    }

    public class ArtistDTO
    {
        public string Name { get; set; }
        public int SongCount { get; set; }
    }
}
