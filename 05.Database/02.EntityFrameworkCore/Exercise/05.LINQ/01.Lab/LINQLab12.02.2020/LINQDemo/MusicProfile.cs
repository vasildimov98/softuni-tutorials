namespace LINQDemo
{
    using AutoMapper;
    using LINQDemo.Models;

    public class MusicProfile : Profile
    {
        public MusicProfile()
        {
            CreateMap<Artist, ArtistDTO>()
                   .ForMember(a => a.SongCount,
                              opt => opt.MapFrom(a => a.SongArtists.Count))
                   .ReverseMap();
        }
    }
}
