using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Betgrab.Domain.Migrations
{
    public partial class Event_Tr_Columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "Events");

            migrationBuilder.AddColumn<byte>(
                name: "Tr1",
                table: "Events",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Tr1OR",
                table: "Events",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Tr2",
                table: "Events",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Tr2OR",
                table: "Events",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Trh1",
                table: "Events",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Trh2",
                table: "Events",
                type: "tinyint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tr1",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Tr1OR",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Tr2",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Tr2OR",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Trh1",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Trh2",
                table: "Events");

            migrationBuilder.AddColumn<byte[]>(
                name: "Result",
                table: "Events",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
