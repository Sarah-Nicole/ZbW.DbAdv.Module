using CodeFirst.VidApp;
using Microsoft.EntityFrameworkCore;
using System;

namespace CodeFirst
{
  internal class Program
  {
    static void Main(string[] args)
    {
            using var db = new VidAppContext();

            var actionMovies = db.Videos
                .Where(v => v.GenreId == 1)     // Action
                .OrderBy(v => v.Name)
                .Select(v => v.Name)
                .ToList();

            foreach (var movie in actionMovies)
                Console.WriteLine(movie);
        }
  }
}
