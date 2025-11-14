namespace CodeFirst.VidApp
{
    using CodeFirst.VidApp.Models;
    using Microsoft.EntityFrameworkCore;

    public class VidAppContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }

        public DbSet<Genre> Genres { get; set; }

        //public DbSet<VideoGenre> VideoGenres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=VidApp_CodeFirst;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Beziehungen definieren
            //modelBuilder.Entity<VideoGenre>()
            //  .HasKey(vg => new { vg.VideoId, vg.GenreId });

            //modelBuilder.Entity<VideoGenre>() 
            //  .HasOne(vg => vg.Video)
            //  .WithMany(v => v.VideoGenres)
            //  .HasForeignKey(vg => vg.VideoId);

          modelBuilder.Entity<Video>()
          .HasOne(v => v.Genre)           // Navigation von Video zu Genre
          .WithMany(g => g.Videos)        // Navigation von Genre zu Videos
          .HasForeignKey(v => v.GenreId); // FK in Tabelle Video
        }
    }
}
