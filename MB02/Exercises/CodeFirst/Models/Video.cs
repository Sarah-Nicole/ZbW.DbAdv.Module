namespace CodeFirst.VidApp.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;

  public class Video
  {
    public int Id { get; set; }

    [Required]
    [MaxLength(255)] // Attribute setzen damit die DB sicher so erstellt wird
    public required string Name { get; set; }

    public DateTime ReleaseDate { get; set; }

    public ICollection<VideoGenre>? VideoGenres { get; set; } // Da Many

  }
}
