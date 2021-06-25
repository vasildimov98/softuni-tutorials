using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LINQDemo.Models
{
    public partial class MusicXContext : DbContext
    {
        public MusicXContext()
        {
        }

        public MusicXContext(DbContextOptions<MusicXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<ArtistMetadata> ArtistMetadatas { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<SongArtist> SongArtists { get; set; }
        public virtual DbSet<SongMetadata> SongMetadatas { get; set; }
        public virtual DbSet<Source> Sources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=.;Database=MusicX;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasIndex(e => e.IsDeleted, "IX_Artists_IsDeleted");
            });

            modelBuilder.Entity<ArtistMetadata>(entity =>
            {
                entity.ToTable("ArtistMetadata");

                entity.HasIndex(e => e.ArtistId, "IX_ArtistMetadata_ArtistId");

                entity.HasIndex(e => e.IsDeleted, "IX_ArtistMetadata_IsDeleted");

                entity.HasIndex(e => e.SourceId, "IX_ArtistMetadata_SourceId");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistMetadatas)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.ArtistMetadatas)
                    .HasForeignKey(d => d.SourceId);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.HasIndex(e => e.IsDeleted, "IX_Songs_IsDeleted");

                entity.HasIndex(e => e.SourceId, "IX_Songs_SourceId");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.SourceId);
            });

            modelBuilder.Entity<SongArtist>(entity =>
            {
                entity.HasIndex(e => e.ArtistId, "IX_SongArtists_ArtistId");

                entity.HasIndex(e => e.IsDeleted, "IX_SongArtists_IsDeleted");

                entity.HasIndex(e => e.SongId, "IX_SongArtists_SongId");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.SongArtists)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.SongArtists)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SongMetadata>(entity =>
            {
                entity.ToTable("SongMetadata");

                entity.HasIndex(e => e.IsDeleted, "IX_SongMetadata_IsDeleted");

                entity.HasIndex(e => e.SongId, "IX_SongMetadata_SongId");

                entity.HasIndex(e => e.SourceId, "IX_SongMetadata_SourceId");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.SongMetadatas)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.SongMetadatas)
                    .HasForeignKey(d => d.SourceId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
