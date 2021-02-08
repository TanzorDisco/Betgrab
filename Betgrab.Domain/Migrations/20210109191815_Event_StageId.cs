using Microsoft.EntityFrameworkCore.Migrations;

namespace Betgrab.Domain.Migrations
{
    public partial class Event_StageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StageId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_StageId",
                table: "Events",
                column: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Stages_StageId",
                table: "Events",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Stages_StageId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_StageId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "Events");
        }
    }
}
