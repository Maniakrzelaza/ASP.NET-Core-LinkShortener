using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VSfirstdotnet.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "longLink",
                table: "links",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "shortLink",
                table: "links",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "longLink",
                table: "links");

            migrationBuilder.DropColumn(
                name: "shortLink",
                table: "links");
        }
    }
}
