using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.DAL.Migrations
{
    public partial class addlastchangeuseridfieldtoobject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeletedUserId",
                table: "BuildObject",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastChangedUser",
                table: "BuildObject",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "BuildObject");

            migrationBuilder.DropColumn(
                name: "LastChangedUser",
                table: "BuildObject");
        }
    }
}
