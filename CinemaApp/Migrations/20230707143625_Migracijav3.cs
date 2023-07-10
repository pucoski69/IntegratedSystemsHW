using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Migrations
{
    public partial class Migracijav3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieGenre",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "SelectedGenre",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedGenre",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "MovieGenre",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
