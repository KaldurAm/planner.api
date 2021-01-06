using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.DAL.Migrations
{
    public partial class Addfilemapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskFile");

            migrationBuilder.CreateTable(
                name: "AttachFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    FileTypeId = table.Column<int>(nullable: false),
                    FileExtensionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachFile_FileExtension_FileExtensionId",
                        column: x => x.FileExtensionId,
                        principalTable: "FileExtension",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachFile_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingObjectId = table.Column<int>(nullable: true),
                    TaskCardId = table.Column<int>(nullable: true),
                    AttachFileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileMap_AttachFile_AttachFileId",
                        column: x => x.AttachFileId,
                        principalTable: "AttachFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileMap_BuildObject_BuildingObjectId",
                        column: x => x.BuildingObjectId,
                        principalTable: "BuildObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FileMap_TaskCard_TaskCardId",
                        column: x => x.TaskCardId,
                        principalTable: "TaskCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttachFile_FileExtensionId",
                table: "AttachFile",
                column: "FileExtensionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachFile_FileTypeId",
                table: "AttachFile",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FileMap_AttachFileId",
                table: "FileMap",
                column: "AttachFileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileMap_BuildingObjectId",
                table: "FileMap",
                column: "BuildingObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FileMap_TaskCardId",
                table: "FileMap",
                column: "TaskCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileMap");

            migrationBuilder.DropTable(
                name: "AttachFile");

            migrationBuilder.CreateTable(
                name: "TaskFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileExtensionId = table.Column<int>(type: "int", nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskCardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskFile_FileExtension_FileExtensionId",
                        column: x => x.FileExtensionId,
                        principalTable: "FileExtension",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskFile_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskFile_TaskCard_TaskCardId",
                        column: x => x.TaskCardId,
                        principalTable: "TaskCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskFile_FileExtensionId",
                table: "TaskFile",
                column: "FileExtensionId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskFile_FileTypeId",
                table: "TaskFile",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskFile_TaskCardId",
                table: "TaskFile",
                column: "TaskCardId");
        }
    }
}
