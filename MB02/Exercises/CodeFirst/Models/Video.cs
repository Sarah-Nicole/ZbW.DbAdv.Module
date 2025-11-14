namespace CodeFirst.VidApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Video
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)] // Attribute setzen damit die DB sicher so erstellt wird
        public required string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public required byte GenreId { get; set; } // FK -> Achtung Typ muss stimmen!

        // Navigation -> wird benötigt für Context
        public required Genre Genre { get; set; } // Genre darf nicht null sein 

        //public ICollection<VideoGenre>? VideoGenres { get; set; } // für Many-Beziehung

        public Classification Classification { get; set; }
    }
}
