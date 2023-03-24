using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concept.Azure.EfCoreSqlServer.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AggressionLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AggressionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AggressionLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BiomeCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BiomeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiomeCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bison",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IsAlive = table.Column<bool>(type: "bit", nullable: false),
                    AggressionLevelId = table.Column<int>(type: "int", nullable: true),
                    BiomeRefId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bison", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bison_AggressionLevel_AggressionLevelId",
                        column: x => x.AggressionLevelId,
                        principalTable: "AggressionLevel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bison_BiomeCategory_BiomeRefId",
                        column: x => x.BiomeRefId,
                        principalTable: "BiomeCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bison_AggressionLevelId",
                table: "Bison",
                column: "AggressionLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Bison_BiomeRefId",
                table: "Bison",
                column: "BiomeRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bison");

            migrationBuilder.DropTable(
                name: "AggressionLevel");

            migrationBuilder.DropTable(
                name: "BiomeCategory");
        }
    }
}
