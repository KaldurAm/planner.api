using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.DAL.Migrations
{
    public partial class addnewtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectPartnerMap_BuildObject_ObjectId",
                table: "ObjectPartnerMap");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectPartnerMap_UserInfo_UserId",
                table: "ObjectPartnerMap");

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildObject_CurrencyId",
                table: "BuildObject",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildObject_Currency_CurrencyId",
                table: "BuildObject",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectPartnerMap_BuildObject_ObjectId",
                table: "ObjectPartnerMap",
                column: "ObjectId",
                principalTable: "BuildObject",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectPartnerMap_UserInfo_UserId",
                table: "ObjectPartnerMap",
                column: "UserId",
                principalTable: "UserInfo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildObject_Currency_CurrencyId",
                table: "BuildObject");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectPartnerMap_BuildObject_ObjectId",
                table: "ObjectPartnerMap");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectPartnerMap_UserInfo_UserId",
                table: "ObjectPartnerMap");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_BuildObject_CurrencyId",
                table: "BuildObject");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectPartnerMap_BuildObject_ObjectId",
                table: "ObjectPartnerMap",
                column: "ObjectId",
                principalTable: "BuildObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectPartnerMap_UserInfo_UserId",
                table: "ObjectPartnerMap",
                column: "UserId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
