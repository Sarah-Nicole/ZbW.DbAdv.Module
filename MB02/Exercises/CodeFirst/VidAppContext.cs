namespace CodeFirst.VidApp
{
    using CodeFirst.VidApp.Models;
    using Microsoft.EntityFrameworkCore;

    public class VidAppContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<VideoTag> VideoTag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=VidApp_CodeFirst;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Video>()
              .HasOne(v => v.Genre)           // Navigation von Video zu Genre
              .WithMany(g => g.Videos)        // Navigation von Genre zu Videos
              .HasForeignKey(v => v.GenreId); // FK in Tabelle Video

            // Beziehungen definieren
            modelBuilder.Entity<VideoTag>() // Verbindungstabelle
             .HasKey(vt => new { vt.VideoId, vt.TagId });

            modelBuilder.Entity<VideoTag>() // Video zu Verbindungstabelle
              .HasOne(vt => vt.Video)
              .WithMany(v => v.VideoTag)
              .HasForeignKey(vt => vt.VideoId);

            modelBuilder.Entity<VideoTag>() // Tag zu Verbindungstabelle
               .HasOne(vt => vt.Tag)
               .WithMany(t => t.VideoTag)
               .HasForeignKey(vt => vt.TagId);

        }
    }
}
