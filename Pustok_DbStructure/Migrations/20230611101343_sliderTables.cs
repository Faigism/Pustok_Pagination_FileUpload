using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok_DbStructure.Migrations
{
    public partial class sliderTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Name2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Txt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Button = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slider");
        }
    }
}
