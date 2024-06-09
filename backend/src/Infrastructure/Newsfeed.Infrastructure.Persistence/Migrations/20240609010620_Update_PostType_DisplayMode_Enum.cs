using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Newsfeed.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update_PostType_DisplayMode_Enum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayMode",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostType",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "DisplayMode_Id",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DisplayMode_Name",
                table: "Posts",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "PostType_Id",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PostType_Name",
                table: "Posts",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayMode_Id",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DisplayMode_Name",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostType_Id",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostType_Name",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "DisplayMode",
                table: "Posts",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostType",
                table: "Posts",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
