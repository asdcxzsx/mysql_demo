using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.MySQL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataLog",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDisable = table.Column<short>(type: "bit", nullable: false),
                    Type = table.Column<string>(maxLength: 20, nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataLog", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataLog_Type",
                table: "DataLog",
                column: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataLog");
        }
    }
}
