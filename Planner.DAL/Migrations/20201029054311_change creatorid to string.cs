using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.DAL.Migrations
{
    public partial class changecreatoridtostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskCard_UserInfo_CreatorId",
                table: "TaskCard");

            migrationBuilder.DropIndex(
                name: "IX_TaskCard_CreatorId",
                table: "TaskCard");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "TaskCard",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "TaskCard",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskCard_CreatorId",
                table: "TaskCard",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCard_UserInfo_CreatorId",
                table: "TaskCard",
                column: "CreatorId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
