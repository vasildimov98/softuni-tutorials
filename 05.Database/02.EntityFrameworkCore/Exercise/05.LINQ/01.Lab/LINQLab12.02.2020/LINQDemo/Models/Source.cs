using System;
using System.Collections.Generic;

#nullable disable

namespace LINQDemo.Models
{
    public partial class Source
    {
        public Source()
        {
            ArtistMetadatas = new HashSet<ArtistMetadata>();
            SongMetadatas = new HashSet<SongMetadata>();
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArtistMetadata> ArtistMetadatas { get; set; }
        public virtual ICollection<SongMetadata> SongMetadatas { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
