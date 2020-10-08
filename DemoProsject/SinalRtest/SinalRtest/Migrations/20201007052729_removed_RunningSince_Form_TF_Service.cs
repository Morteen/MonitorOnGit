using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SinalRtest.Migrations
{
    public partial class removed_RunningSince_Form_TF_Service : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RunningSince",
                table: "TF_Services");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RunningSince",
                table: "TF_Services",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
