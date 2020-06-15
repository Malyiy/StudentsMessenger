using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsMessenger.Migrations
{
    public partial class _mythreemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Works",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "Works",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Works");
        }
    }
}
