using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class DbMusicContext : DbContext
    {
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Musician_Track> MusicianTracks { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        
        public DbMusicContext(DbContextOptions options) : base(options)
        {
        }
        
          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var musicians = new List<Musician>{
                new Musician(){
                    IdMusician = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    NickName = "jsmith"
                },
                new Musician(){
                    IdMusician = 2,
                    FirstName = "Franklin",
                    LastName = "Ward",
                    NickName = "frank"
                },
                new Musician(){
                    IdMusician = 3,
                    FirstName = "Tom",
                    LastName = "Blake",
                    NickName = "TB"
                },
                new Musician(){ 
                    IdMusician = 4,
                    FirstName = "Kim",
                    LastName = "White",
                    NickName = "WhiteK"
                },
                new Musician(){ 
                    IdMusician = 5,
                    FirstName = "Ken",
                    LastName = "Lee",
                    NickName = "Kee"
                }
            };
            
            var musicianTracks = new List<Musician_Track>{
                new Musician_Track(){
                    IdTrack = 1,
                    IdMusician = 1
                },
                new Musician_Track(){
                    IdTrack = 2,
                    IdMusician = 2
                },
                new Musician_Track(){
                    IdTrack = 3,
                    IdMusician = 3
                },
                new Musician_Track(){
                    IdTrack = 4,
                    IdMusician = 3
                },
                new Musician_Track(){
                    IdTrack = 5,
                    IdMusician = 1
                },
                new Musician_Track(){
                    IdTrack = 6,
                    IdMusician = 1
                },
                new Musician_Track(){
                    IdTrack = 7,
                    IdMusician = 2
                },
                new Musician_Track(){
                    IdTrack = 8,
                    IdMusician = 2
                },
                new Musician_Track(){
                    IdTrack = 8,
                    IdMusician = 5
                },
                new Musician_Track(){
                    IdTrack = 9,
                    IdMusician = 4
                },
                new Musician_Track(){
                    IdTrack = 9,
                    IdMusician = 5
                },
            };
            
            var tracks = new List<Track>{
                new Track(){
                    IdTrack = 1,
                    TrackName = "Shadow",
                    Duration = 3.33,
                    IdMusicAlbum = 1
                },
                new Track(){
                    IdTrack = 2,
                    TrackName = "Eyes",
                    Duration = 3.20,
                    IdMusicAlbum = 1
                },
                new Track(){
                    IdTrack = 3,
                    TrackName = "Sunny",
                    Duration = 2.58,
                    IdMusicAlbum = 1
                },
                new Track(){
                    IdTrack = 4,
                    TrackName = "Ocean",
                    Duration = 3.18,
                    IdMusicAlbum = 2
                },
                new Track(){
                    IdTrack = 5,
                    TrackName = "Yellow",
                    Duration = 2.58,
                    IdMusicAlbum = 2
                },
                new Track(){
                    IdTrack = 6,
                    TrackName = "Thank you",
                    Duration = 3.08,
                    IdMusicAlbum = 2
                },
                new Track(){
                    IdTrack = 7,
                    TrackName = "Cake",
                    Duration = 3.19,
                    IdMusicAlbum = 3
                },
                new Track(){
                    IdTrack = 8,
                    TrackName = "Bye bye",
                    Duration = 2.58,
                    IdMusicAlbum = 3
                },
                new Track(){
                    IdTrack = 9,
                    TrackName = "Love",
                    Duration = 3.18,
                    IdMusicAlbum = null
                },
            };
            
            var albums = new List<Album>{
                new Album(){
                    IdAlbum = 1,
                    AlbumName = "You",
                    PublishDate = DateTime.Parse("1998-07-13 8:00:00"),
                    IdMusicLabel = 1
                },
                new Album(){
                    IdAlbum = 2,
                    AlbumName = "Summer",
                    PublishDate = DateTime.Parse("1999-02-04 11:00:00"),
                    IdMusicLabel = 1
                },
                new Album(){
                    IdAlbum = 3,
                    AlbumName = "Good vibes",
                    PublishDate = DateTime.Parse("1996-09-02 1:00:00"),
                    IdMusicLabel = 3
                },
            };
            
            var musicLabels = new List<MusicLabel>{
                new MusicLabel(){
                    IdMusicLabel = 1,
                    Name = "MusicAllDay",
                },
                new MusicLabel(){
                    IdMusicLabel = 2,
                    Name = "OnlyMusic",
                },
                new MusicLabel(){
                    IdMusicLabel = 3,
                    Name = "LoveMusic",
                },
            };
            
            modelBuilder.Entity<Musician>(e =>
            {
                e.HasKey(e => e.IdMusician);
                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.NickName).HasMaxLength(20);

                e.HasData(musicians);
                e.ToTable("Musician");
            });
            
            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Duration).IsRequired();
                e.Property(e => e.IdMusicAlbum);
                
                e.HasOne(e => e.Album)
                    .WithMany(e => e.Track)
                    .HasForeignKey(e => e.IdMusicAlbum);

                e.HasData(tracks);
                e.ToTable("Track");
            });
            
            modelBuilder.Entity<Musician_Track>(e =>
            {
                e.HasKey(e => new { e.IdTrack, e.IdMusician });

                e.HasOne(e => e.Track)
                    .WithMany(e => e.Musician_Track)
                    .HasForeignKey(e => e.IdTrack);

                e.HasOne(e => e.Musician)
                    .WithMany(e => e.Musician_Track)
                    .HasForeignKey(e => e.IdMusician);

                e.HasData(musicianTracks);
                e.ToTable("Musician_Track");
            });
            
            modelBuilder.Entity<Album>(e =>
            {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
                e.Property(e => e.PublishDate).IsRequired();
                e.Property(e => e.IdMusicLabel).IsRequired();

                e.HasOne(e => e.MusicLabel)
                    .WithMany(e => e.Album)
                    .HasForeignKey(e => e.IdMusicLabel);

                e.HasData(albums);
                e.ToTable("Album");
            });
            
            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).HasMaxLength(50).IsRequired();
                
                e.HasData(musicLabels);
                e.ToTable("MusicLabel");
            });
        }
    }
}