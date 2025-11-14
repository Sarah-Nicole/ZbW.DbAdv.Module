using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.VidApp.Migrations
{
    /// <inheritdoc />
    public partial class updateEnumClassification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Classification",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classification",
                table: "Videos");
        }
    }
}
