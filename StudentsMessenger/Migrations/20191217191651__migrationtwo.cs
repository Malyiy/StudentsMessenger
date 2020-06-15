using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsMessenger.Migrations
{
    public partial class _migrationtwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Works",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Works_StudentId",
                table: "Works",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_AspNetUsers_StudentId",
                table: "Works",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_AspNetUsers_StudentId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_StudentId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Works");
        }
    }
}
