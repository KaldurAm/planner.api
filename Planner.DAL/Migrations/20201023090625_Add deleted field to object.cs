using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.DAL.Migrations
{
    public partial class Adddeletedfieldtoobject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "BuildObject",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "BuildObject");
        }
    }
}
