using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.DAL.Migrations
{
    public partial class Adduseridfortask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplyByUser",
                table: "TaskCard",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedByUser",
                table: "TaskCard",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplyByUser",
                table: "TaskCard");

            migrationBuilder.DropColumn(
                name: "DeletedByUser",
                table: "TaskCard");
        }
    }
}
