using Microsoft.EntityFrameworkCore.Migrations;

namespace Betgrab.Domain.Migrations
{
    public partial class Fact_Redesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Penalties");

            migrationBuilder.DropTable(
                name: "PenaltyCards");

            migrationBuilder.DropTable(
                name: "PlayerDeletions");

            migrationBuilder.DropTable(
                name: "PlayerSubstitutions");

            migrationBuilder.CreateTable(
                name: "Facts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivescoreId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Min = table.Column<byte>(type: "tinyint", nullable: false),
                    MinEx = table.Column<byte>(type: "tinyint", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facts_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facts_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facts_EventId",
                table: "Facts",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_PlayerId",
                table: "Facts",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facts");

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    JsonData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LivescoreId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goals_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goals_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goals_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Penalties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Club1Id = table.Column<int>(type: "int", nullable: false),
                    Club2Id = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    JsonData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LivescoreId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Penalties_Clubs_Club1Id",
                        column: x => x.Club1Id,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Penalties_Clubs_Club2Id",
                        column: x => x.Club2Id,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Penalties_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PenaltyCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    IsRed = table.Column<bool>(type: "bit", nullable: false),
                    JsonData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LivescoreId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PenaltyCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PenaltyCards_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PenaltyCards_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerDeletions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    JsonData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LivescoreId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerDeletions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerDeletions_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerDeletions_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSubstitutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    InId = table.Column<int>(type: "int", nullable: false),
                    JsonData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LivescoreId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSubstitutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerSubstitutions_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerSubstitutions_Players_InId",
                        column: x => x.InId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerSubstitutions_Players_OutId",
                        column: x => x.OutId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goals_ClubId",
                table: "Goals",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_EventId",
                table: "Goals",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_PlayerId",
                table: "Goals",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_Club1Id",
                table: "Penalties",
                column: "Club1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_Club2Id",
                table: "Penalties",
                column: "Club2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_EventId",
                table: "Penalties",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_PenaltyCards_EventId",
                table: "PenaltyCards",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_PenaltyCards_PlayerId",
                table: "PenaltyCards",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDeletions_EventId",
                table: "PlayerDeletions",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDeletions_PlayerId",
                table: "PlayerDeletions",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSubstitutions_EventId",
                table: "PlayerSubstitutions",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSubstitutions_InId",
                table: "PlayerSubstitutions",
                column: "InId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSubstitutions_OutId",
                table: "PlayerSubstitutions",
                column: "OutId");
        }
    }
}
