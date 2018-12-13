using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.MySQL.Migrations
{
    public partial class Add_IDX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DataLog_Type",
                table: "DataLog",
                column: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DataLog_Type",
                table: "DataLog");
        }
    }
}
