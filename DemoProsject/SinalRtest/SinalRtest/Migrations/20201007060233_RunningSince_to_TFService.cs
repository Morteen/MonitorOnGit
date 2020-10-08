using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SinalRtest.Migrations
{
    public partial class RunningSince_to_TFService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RunningSince",
                table: "TF_Services",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RunningSince",
                table: "TF_Services");
        }
    }
}
