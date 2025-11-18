namespace CodeFirst.VidApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation
        public ICollection<Video> Videos { get; set; }
    }
}
