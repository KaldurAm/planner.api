using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.DAL.Migrations
{
    public partial class addnewfieldforcolor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "TaskColor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "TaskColor");
        }
    }
}
