using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.DAL.Migrations
{
    public partial class Addedtopropertiestoobject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Area",
                table: "BuildObject",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "CadastralNumber",
                table: "BuildObject",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "BuildObject",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "BuildObject",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "BuildObject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ObjectStatusId",
                table: "BuildObject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "BuildObject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "BuildObject",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "BuildObject",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AreaProperty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaProperty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectPartnerMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ObjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectPartnerMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectPartnerMap_BuildObject_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "BuildObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectPartnerMap_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildObject_ObjectStatusId",
                table: "BuildObject",
                column: "ObjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildObject_PropertyId",
                table: "BuildObject",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectPartnerMap_ObjectId",
                table: "ObjectPartnerMap",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectPartnerMap_UserId",
                table: "ObjectPartnerMap",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildObject_ObjectStatus_ObjectStatusId",
                table: "BuildObject",
                column: "ObjectStatusId",
                principalTable: "ObjectStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildObject_AreaProperty_PropertyId",
                table: "BuildObject",
                column: "PropertyId",
                principalTable: "AreaProperty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildObject_ObjectStatus_ObjectStatusId",
                table: "BuildObject");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildObject_AreaProperty_PropertyId",
                table: "BuildObject");

            migrationBuilder.DropTable(
                name: "AreaProperty");

            migrationBuilder.DropTable(
                name: "ObjectPartnerMap");

            migrationBuilder.DropTable(
                name: "ObjectStatus");

            migrationBuilder.DropIndex(
                name: "IX_BuildObject_ObjectStatusId",
                table: "BuildObject");

            migrationBuilder.DropIndex(
                name: "IX_BuildObject_PropertyId",
                table: "BuildObject");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "BuildObject");

            migrationBuilder.DropColumn(
                name: "CadastralNumber",
                table: "BuildObject");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "BuildObject");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "BuildObject");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "BuildObject");

            migrationBuilder.DropColumn(
                name: "ObjectStatusId",
                table: "BuildObject");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "BuildObject");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "BuildObject");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "BuildObject");
        }
    }
}
