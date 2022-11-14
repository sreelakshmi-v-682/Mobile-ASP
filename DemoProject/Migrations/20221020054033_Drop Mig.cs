using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoProject.Migrations
{
    public partial class DropMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mobiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mobiles",
                columns: table => new
                {
                    MobileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Catogery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Photopath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mobiles", x => x.MobileId);
                });
        }
    }
}
