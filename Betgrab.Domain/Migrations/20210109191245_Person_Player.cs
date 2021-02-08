using Microsoft.EntityFrameworkCore.Migrations;

namespace Betgrab.Domain.Migrations
{
    public partial class Person_Player : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubMember_Persons_PersonId",
                table: "ClubMember");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Persons_PersonId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_PenaltyCards_Persons_PersonId",
                table: "PenaltyCards");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerDeletions_Persons_PersonId",
                table: "PlayerDeletions");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerSubstitutions_Persons_InId",
                table: "PlayerSubstitutions");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerSubstitutions_Persons_OutId",
                table: "PlayerSubstitutions");

            migrationBuilder.DropTable(
                name: "NationPerson");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "PlayerDeletions",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerDeletions_PersonId",
                table: "PlayerDeletions",
                newName: "IX_PlayerDeletions_PlayerId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "PenaltyCards",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PenaltyCards_PersonId",
                table: "PenaltyCards",
                newName: "IX_PenaltyCards_PlayerId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Goals",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_PersonId",
                table: "Goals",
                newName: "IX_Goals_PlayerId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "ClubMember",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_ClubMember_PersonId",
                table: "ClubMember",
                newName: "IX_ClubMember_PlayerId");

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivescoreId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NationPlayer",
                columns: table => new
                {
                    CitizensId = table.Column<int>(type: "int", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationPlayer", x => new { x.CitizensId, x.NationalityId });
                    table.ForeignKey(
                        name: "FK_NationPlayer_Nations_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NationPlayer_Players_CitizensId",
                        column: x => x.CitizensId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NationPlayer_NationalityId",
                table: "NationPlayer",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubMember_Players_PlayerId",
                table: "ClubMember",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Players_PlayerId",
                table: "Goals",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PenaltyCards_Players_PlayerId",
                table: "PenaltyCards",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerDeletions_Players_PlayerId",
                table: "PlayerDeletions",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerSubstitutions_Players_InId",
                table: "PlayerSubstitutions",
                column: "InId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerSubstitutions_Players_OutId",
                table: "PlayerSubstitutions",
                column: "OutId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubMember_Players_PlayerId",
                table: "ClubMember");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Players_PlayerId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_PenaltyCards_Players_PlayerId",
                table: "PenaltyCards");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerDeletions_Players_PlayerId",
                table: "PlayerDeletions");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerSubstitutions_Players_InId",
                table: "PlayerSubstitutions");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerSubstitutions_Players_OutId",
                table: "PlayerSubstitutions");

            migrationBuilder.DropTable(
                name: "NationPlayer");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "PlayerDeletions",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerDeletions_PlayerId",
                table: "PlayerDeletions",
                newName: "IX_PlayerDeletions_PersonId");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "PenaltyCards",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_PenaltyCards_PlayerId",
                table: "PenaltyCards",
                newName: "IX_PenaltyCards_PersonId");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Goals",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_PlayerId",
                table: "Goals",
                newName: "IX_Goals_PersonId");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "ClubMember",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_ClubMember_PlayerId",
                table: "ClubMember",
                newName: "IX_ClubMember_PersonId");

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LivescoreId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NationPerson",
                columns: table => new
                {
                    CitizensId = table.Column<int>(type: "int", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationPerson", x => new { x.CitizensId, x.NationalityId });
                    table.ForeignKey(
                        name: "FK_NationPerson_Nations_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NationPerson_Persons_CitizensId",
                        column: x => x.CitizensId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NationPerson_NationalityId",
                table: "NationPerson",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubMember_Persons_PersonId",
                table: "ClubMember",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Persons_PersonId",
                table: "Goals",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PenaltyCards_Persons_PersonId",
                table: "PenaltyCards",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerDeletions_Persons_PersonId",
                table: "PlayerDeletions",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerSubstitutions_Persons_InId",
                table: "PlayerSubstitutions",
                column: "InId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerSubstitutions_Persons_OutId",
                table: "PlayerSubstitutions",
                column: "OutId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
