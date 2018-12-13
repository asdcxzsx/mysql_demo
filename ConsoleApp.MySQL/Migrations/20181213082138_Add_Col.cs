using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.MySQL.Migrations
{
    public partial class Add_Col : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "DataLog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "DataLog");
        }
    }
}
