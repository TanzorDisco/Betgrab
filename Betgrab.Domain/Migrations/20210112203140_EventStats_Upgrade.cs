using Microsoft.EntityFrameworkCore.Migrations;

namespace Betgrab.Domain.Migrations
{
    public partial class EventStats_Upgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CounterAttacks",
                table: "EventStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Crosses",
                table: "EventStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalkeeperSaves",
                table: "EventStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RedCards",
                table: "EventStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Treatments",
                table: "EventStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YellowRedCards",
                table: "EventStats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CounterAttacks",
                table: "EventStats");

            migrationBuilder.DropColumn(
                name: "Crosses",
                table: "EventStats");

            migrationBuilder.DropColumn(
                name: "GoalkeeperSaves",
                table: "EventStats");

            migrationBuilder.DropColumn(
                name: "RedCards",
                table: "EventStats");

            migrationBuilder.DropColumn(
                name: "Treatments",
                table: "EventStats");

            migrationBuilder.DropColumn(
                name: "YellowRedCards",
                table: "EventStats");
        }
    }
}
