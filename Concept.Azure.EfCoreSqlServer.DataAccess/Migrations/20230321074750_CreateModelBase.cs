using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concept.Azure.EfCoreSqlServer.DataAccess.Migrations
{
    public partial class CreateModelBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Bison",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateUtc",
                table: "Bison",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Bison",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateUtc",
                table: "Bison",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BiomeCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateUtc",
                table: "BiomeCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "BiomeCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateUtc",
                table: "BiomeCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AggressionLevel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateUtc",
                table: "AggressionLevel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "AggressionLevel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateUtc",
                table: "AggressionLevel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Bison");

            migrationBuilder.DropColumn(
                name: "CreatedDateUtc",
                table: "Bison");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Bison");

            migrationBuilder.DropColumn(
                name: "ModifiedDateUtc",
                table: "Bison");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BiomeCategory");

            migrationBuilder.DropColumn(
                name: "CreatedDateUtc",
                table: "BiomeCategory");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "BiomeCategory");

            migrationBuilder.DropColumn(
                name: "ModifiedDateUtc",
                table: "BiomeCategory");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AggressionLevel");

            migrationBuilder.DropColumn(
                name: "CreatedDateUtc",
                table: "AggressionLevel");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AggressionLevel");

            migrationBuilder.DropColumn(
                name: "ModifiedDateUtc",
                table: "AggressionLevel");
        }
    }
}
