namespace LINQDemo
{
    using System.Linq;
    using System.Collections.Generic;

    using Models;

    public interface IArtistServer
    {
        IEnumerable<ArtistDTO> GetArtistInfo();
    }

    public class ArtistServer : IArtistServer
    {
        private readonly MusicXContext context;

        public ArtistServer(MusicXContext dbContext)
        {
            this.context = dbContext;
        }

        public IEnumerable<ArtistDTO> GetArtistInfo()
        {
            return this.context.Artists
                .Select(a => new ArtistDTO
                {
                    Name = a.Name,
                    SongCount = a.SongArtists.Count()
                })
                .OrderByDescending(s => s.SongCount)
                .Take(10)
                .AsEnumerable();
        }
    }
}
