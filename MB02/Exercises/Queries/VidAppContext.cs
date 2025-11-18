namespace CodeFirst.VidApp
{
    using CodeFirst.VidApp.Models;
    using Microsoft.EntityFrameworkCore;

    public class VidAppContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VideoTag> VideoTag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=VidApp_Queries;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Video → Genre (1:n)
            modelBuilder.Entity<Video>()
                .HasOne(v => v.Genre)
                .WithMany(g => g.Videos)
                .HasForeignKey(v => v.GenreId);

            // Primärschlüssel der Many-to-Many Tabelle
            modelBuilder.Entity<VideoTag>()
                .HasKey(vt => new { vt.VideoId, vt.TagId });

            // Video → VideoTags (1:n)
            modelBuilder.Entity<VideoTag>()
                .HasOne(vt => vt.Video)
                .WithMany(v => v.VideoTag)
                .HasForeignKey(vt => vt.VideoId);

            // Tag → VideoTags (1:n)
            modelBuilder.Entity<VideoTag>()
                .HasOne(vt => vt.Tag)
                .WithMany(t => t.VideoTag)
                .HasForeignKey(vt => vt.TagId);
        }
    }
}
