using System;
using System.Collections.Generic;

#nullable disable

namespace LINQDemo.Models
{
    public partial class Artist
    {
        public Artist()
        {
            ArtistMetadatas = new HashSet<ArtistMetadata>();
            SongArtists = new HashSet<SongArtist>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArtistMetadata> ArtistMetadatas { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
    }
}
