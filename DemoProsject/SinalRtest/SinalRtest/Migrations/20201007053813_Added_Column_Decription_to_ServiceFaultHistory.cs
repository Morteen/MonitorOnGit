using Microsoft.EntityFrameworkCore.Migrations;

namespace SinalRtest.Migrations
{
    public partial class Added_Column_Decription_to_ServiceFaultHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ServicefaultHistory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ServicefaultHistory");
        }
    }
}
