using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Newsfeed.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Audiable_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Reaction",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Reaction",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "EditVersion",
                table: "Reaction",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Reaction",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Reaction",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Posts",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Posts",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "EditVersion",
                table: "Posts",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Posts",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Posts",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Categorys",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Categorys",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "EditVersion",
                table: "Categorys",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Categorys",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Categorys",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "EditVersion",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "EditVersion",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Categorys");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categorys");

            migrationBuilder.DropColumn(
                name: "EditVersion",
                table: "Categorys");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Categorys");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Categorys");
        }
    }
}
