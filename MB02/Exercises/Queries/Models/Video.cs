namespace CodeFirst.VidApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Classification { get; set; }

        public int GenreId { get; set; }

        // Navigation
        public Genre Genre { get; set; }
        public ICollection<VideoTag> VideoTag { get; set; }
    }
}
