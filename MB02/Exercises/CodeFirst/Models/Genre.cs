namespace CodeFirst.VidApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }

        // Navigation (ein Genre kann viele Videos haben, oder null) -> wird benötigt für Context
        public ICollection<Video>? Videos { get; set; }

        // public ICollection<VideoGenre>? VideoGenres { get; set; } // für Many-Beziehung
    }
}
