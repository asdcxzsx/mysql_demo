using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.MySQL.Migrations
{
    public partial class RemoveIDX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DataLog_Type",
                table: "DataLog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DataLog_Type",
                table: "DataLog",
                column: "Type");
        }
    }
}
