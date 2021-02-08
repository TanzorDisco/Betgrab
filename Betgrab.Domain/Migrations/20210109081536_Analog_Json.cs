using Microsoft.EntityFrameworkCore.Migrations;

namespace Betgrab.Domain.Migrations
{
    public partial class Analog_Json : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Json",
                table: "Analogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "Json",
                table: "Analogs");
        }
    }
}
