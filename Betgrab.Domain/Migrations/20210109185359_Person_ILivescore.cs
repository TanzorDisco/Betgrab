using Microsoft.EntityFrameworkCore.Migrations;

namespace Betgrab.Domain.Migrations
{
    public partial class Person_ILivescore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LivescoreId",
                table: "PlayerSubstitutions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LivescoreId",
                table: "PlayerDeletions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LivescoreId",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "LivescoreId",
                table: "PenaltyCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LivescoreId",
                table: "Penalties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LivescoreId",
                table: "Goals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LivescoreId",
                table: "PlayerSubstitutions");

            migrationBuilder.DropColumn(
                name: "LivescoreId",
                table: "PlayerDeletions");

            migrationBuilder.DropColumn(
                name: "LivescoreId",
                table: "PenaltyCards");

            migrationBuilder.DropColumn(
                name: "LivescoreId",
                table: "Penalties");

            migrationBuilder.DropColumn(
                name: "LivescoreId",
                table: "Goals");

            migrationBuilder.AlterColumn<int>(
                name: "LivescoreId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
