using Microsoft.EntityFrameworkCore.Migrations;

namespace Betgrab.Domain.Migrations
{
    public partial class Livescore_Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LivescoreId",
                table: "Stages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LivescoreId",
                table: "Players",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LivescoreId",
                table: "Nations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LivescoreId",
                table: "Leagues",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LivescoreId",
                table: "Facts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LivescoreId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LivescoreId",
                table: "Clubs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stages_LivescoreId",
                table: "Stages",
                column: "LivescoreId",
                unique: true,
                filter: "[LivescoreId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Players_LivescoreId",
                table: "Players",
                column: "LivescoreId",
                unique: true,
                filter: "[LivescoreId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Nations_LivescoreId",
                table: "Nations",
                column: "LivescoreId",
                unique: true,
                filter: "[LivescoreId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_LivescoreId",
                table: "Leagues",
                column: "LivescoreId",
                unique: true,
                filter: "[LivescoreId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_LivescoreId",
                table: "Facts",
                column: "LivescoreId",
                unique: true,
                filter: "[LivescoreId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LivescoreId",
                table: "Events",
                column: "LivescoreId",
                unique: true,
                filter: "[LivescoreId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_LivescoreId",
                table: "Clubs",
                column: "LivescoreId",
                unique: true,
                filter: "[LivescoreId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stages_LivescoreId",
                table: "Stages");

            migrationBuilder.DropIndex(
                name: "IX_Players_LivescoreId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Nations_LivescoreId",
                table: "Nations");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_LivescoreId",
                table: "Leagues");

            migrationBuilder.DropIndex(
                name: "IX_Facts_LivescoreId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_Events_LivescoreId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_LivescoreId",
                table: "Clubs");

            migrationBuilder.AlterColumn<string>(
                name: "LivescoreId",
                table: "Stages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LivescoreId",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LivescoreId",
                table: "Nations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LivescoreId",
                table: "Leagues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LivescoreId",
                table: "Facts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LivescoreId",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LivescoreId",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
