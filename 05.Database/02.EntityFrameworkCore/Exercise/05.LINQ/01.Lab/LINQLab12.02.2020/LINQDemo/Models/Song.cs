using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LINQDemo.Models
{
    public partial class Song
    {
        public Song()
        {
            SongArtists = new HashSet<SongArtist>();
            SongMetadatas = new HashSet<SongMetadata>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }
        public int? SourceId { get; set; }
        public string SourceItemId { get; set; }
        public string SearchTerms { get; set; }

        public virtual Source Source { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
        public virtual ICollection<SongMetadata> SongMetadatas { get; set; }
    }
}
