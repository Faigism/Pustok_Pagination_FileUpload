﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok_DbStructure.Migrations
{
    public partial class AuthorTableSetImageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Authors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Authors");
        }
    }
}
