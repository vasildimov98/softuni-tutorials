﻿namespace P00.DatabaseFirstDemo.Modules
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    #nullable disable

    public partial class Source
    {
        public Source()
        {
            ArtistMetadata = new HashSet<ArtistMetadatum>();
            SongMetadata = new HashSet<SongMetadatum>();
            Songs = new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Name { get; set; }

        [InverseProperty(nameof(ArtistMetadatum.Source))]
        public virtual ICollection<ArtistMetadatum> ArtistMetadata { get; set; }
        [InverseProperty(nameof(SongMetadatum.Source))]
        public virtual ICollection<SongMetadatum> SongMetadata { get; set; }
        [InverseProperty(nameof(Song.Source))]
        public virtual ICollection<Song> Songs { get; set; }
    }
}
