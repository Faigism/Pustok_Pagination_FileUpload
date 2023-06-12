using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok_DbStructure.Migrations
{
    public partial class SliderTableUpdateSliderId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SliderId",
                table: "Slider",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderId",
                table: "Slider");
        }
    }
}
