using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.Migrations
{
    public partial class Migrationsv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieGenre",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieGenre",
                table: "Tickets");
        }
    }
}
