using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SinalRtest.Migrations
{
    public partial class made_FaultTime_nullebal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FaultTime",
                table: "ServicefaultHistory",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FaultTime",
                table: "ServicefaultHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
