using Microsoft.EntityFrameworkCore.Migrations;

namespace Betgrab.Domain.Migrations
{
    public partial class NationId_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Nations_CountryId",
                table: "Clubs");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Clubs",
                newName: "NationId");

            migrationBuilder.RenameIndex(
                name: "IX_Clubs_CountryId",
                table: "Clubs",
                newName: "IX_Clubs_NationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Nations_NationId",
                table: "Clubs",
                column: "NationId",
                principalTable: "Nations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Nations_NationId",
                table: "Clubs");

            migrationBuilder.RenameColumn(
                name: "NationId",
                table: "Clubs",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Clubs_NationId",
                table: "Clubs",
                newName: "IX_Clubs_CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Nations_CountryId",
                table: "Clubs",
                column: "CountryId",
                principalTable: "Nations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
