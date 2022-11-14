using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoProject.Migrations
{
    public partial class addMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mobiles",
                columns: table => new
                {
                    MobileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MobileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Catogery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Photopath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mobiles", x => x.MobileId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mobiles");
        }
    }
}
