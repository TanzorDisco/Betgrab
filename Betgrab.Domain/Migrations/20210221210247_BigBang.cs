using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Betgrab.Domain.Migrations
{
    public partial class BigBang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LivescoreId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LivescoreId = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    PositionName = table.Column<string>(type: "text", nullable: true),
                    PlayerNumber = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(2000)", nullable: true),
                    LivescoreId = table.Column<string>(type: "text", nullable: true),
                    NationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clubs_Nations_NationId",
                        column: x => x.NationId,
                        principalTable: "Nations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NationId = table.Column<int>(type: "integer", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    IsInternational = table.Column<bool>(type: "boolean", nullable: false),
                    LivescoreId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leagues_Nations_NationId",
                        column: x => x.NationId,
                        principalTable: "Nations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NationPlayer",
                columns: table => new
                {
                    CitizensId = table.Column<int>(type: "integer", nullable: false),
                    NationalityId = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ClubMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClubId = table.Column<int>(type: "integer", nullable: false),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsLeasing = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubMember_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubMember_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClubLeague",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LeagueId = table.Column<int>(type: "integer", nullable: false),
                    ClubId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubLeague", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubLeague_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubLeague_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LivescoreId = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LeagueId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stages_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Tr1 = table.Column<byte>(type: "smallint", nullable: true),
                    Tr2 = table.Column<byte>(type: "smallint", nullable: true),
                    Trh1 = table.Column<byte>(type: "smallint", nullable: true),
                    Trh2 = table.Column<byte>(type: "smallint", nullable: true),
                    Tr1OR = table.Column<byte>(type: "smallint", nullable: true),
                    Tr2OR = table.Column<byte>(type: "smallint", nullable: true),
                    LivescoreId = table.Column<string>(type: "text", nullable: true),
                    Club1Id = table.Column<int>(type: "integer", nullable: true),
                    Club2Id = table.Column<int>(type: "integer", nullable: true),
                    IsCancelled = table.Column<bool>(type: "boolean", nullable: false),
                    StageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Clubs_Club1Id",
                        column: x => x.Club1Id,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Clubs_Club2Id",
                        column: x => x.Club2Id,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: true),
                    ClubId = table.Column<int>(type: "integer", nullable: true),
                    ShotsOnTarget = table.Column<int>(type: "integer", nullable: false),
                    ShotsOffTarget = table.Column<int>(type: "integer", nullable: false),
                    ShotsBlocked = table.Column<int>(type: "integer", nullable: false),
                    Possession = table.Column<int>(type: "integer", nullable: false),
                    CornerKicks = table.Column<int>(type: "integer", nullable: false),
                    Offsides = table.Column<int>(type: "integer", nullable: false),
                    Fouls = table.Column<int>(type: "integer", nullable: false),
                    ThrowIns = table.Column<int>(type: "integer", nullable: false),
                    YellowCards = table.Column<int>(type: "integer", nullable: false),
                    YellowRedCards = table.Column<int>(type: "integer", nullable: false),
                    RedCards = table.Column<int>(type: "integer", nullable: false),
                    Crosses = table.Column<int>(type: "integer", nullable: false),
                    CounterAttacks = table.Column<int>(type: "integer", nullable: false),
                    GoalkeeperSaves = table.Column<int>(type: "integer", nullable: false),
                    GoalKicks = table.Column<int>(type: "integer", nullable: false),
                    Treatments = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventStats_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventStats_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LivescoreId = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Min = table.Column<byte>(type: "smallint", nullable: false),
                    MinEx = table.Column<byte>(type: "smallint", nullable: true),
                    EventId = table.Column<int>(type: "integer", nullable: true),
                    PlayerId = table.Column<int>(type: "integer", nullable: true)
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
                name: "IX_ClubLeague_ClubId",
                table: "ClubLeague",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubLeague_LeagueId",
                table: "ClubLeague",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubMember_ClubId",
                table: "ClubMember",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubMember_PlayerId",
                table: "ClubMember",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_LivescoreId",
                table: "Clubs",
                column: "LivescoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_NationId",
                table: "Clubs",
                column: "NationId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Club1Id",
                table: "Events",
                column: "Club1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Club2Id",
                table: "Events",
                column: "Club2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LivescoreId",
                table: "Events",
                column: "LivescoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_StageId",
                table: "Events",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_EventStats_ClubId",
                table: "EventStats",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_EventStats_EventId",
                table: "EventStats",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_EventId",
                table: "Facts",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_LivescoreId",
                table: "Facts",
                column: "LivescoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facts_PlayerId",
                table: "Facts",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_LivescoreId",
                table: "Leagues",
                column: "LivescoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_NationId",
                table: "Leagues",
                column: "NationId");

            migrationBuilder.CreateIndex(
                name: "IX_NationPlayer_NationalityId",
                table: "NationPlayer",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Nations_LivescoreId",
                table: "Nations",
                column: "LivescoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_LivescoreId",
                table: "Players",
                column: "LivescoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stages_LeagueId",
                table: "Stages",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_LivescoreId",
                table: "Stages",
                column: "LivescoreId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubLeague");

            migrationBuilder.DropTable(
                name: "ClubMember");

            migrationBuilder.DropTable(
                name: "EventStats");

            migrationBuilder.DropTable(
                name: "Facts");

            migrationBuilder.DropTable(
                name: "NationPlayer");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Nations");
        }
    }
}
