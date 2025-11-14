using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.VidApp.Migrations
{
    /// <inheritdoc />
    public partial class updateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO genres (id, name) VALUES (1, 'Horror')");
            migrationBuilder.Sql("INSERT INTO videos (name, releasedate) VALUES ( 'Mein Video', '2008-11-11')");
            migrationBuilder.Sql("INSERT INTO VideoGenres (VideoId, GenreId) SELECT v.Id, 1 FROM Videos v WHERE v.Name = 'Mein Video';");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM VideoGenres WHERE GenreId = 1;");
            migrationBuilder.Sql("DELETE FROM Videos WHERE Name = 'Mein Video';");
            migrationBuilder.Sql("DELETE FROM Genres WHERE Id = 1;");
        }
    }
}
