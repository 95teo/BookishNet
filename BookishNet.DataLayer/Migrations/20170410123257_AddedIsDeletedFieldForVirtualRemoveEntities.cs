using Microsoft.EntityFrameworkCore.Migrations;

namespace BookishNet.DataLayer.Migrations
{
    public partial class AddedIsDeletedFieldForVirtualRemoveEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                "IsDeleted",
                "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                "IsDeleted",
                "Roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                "IsDeleted",
                "Reviews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                "IsDeleted",
                "Messages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                "IsDeleted",
                "Genres",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                "IsDeleted",
                "Books",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                "IsDeleted",
                "Authors",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "IsDeleted",
                "Users");

            migrationBuilder.DropColumn(
                "IsDeleted",
                "Roles");

            migrationBuilder.DropColumn(
                "IsDeleted",
                "Reviews");

            migrationBuilder.DropColumn(
                "IsDeleted",
                "Messages");

            migrationBuilder.DropColumn(
                "IsDeleted",
                "Genres");

            migrationBuilder.DropColumn(
                "IsDeleted",
                "Books");

            migrationBuilder.DropColumn(
                "IsDeleted",
                "Authors");
        }
    }
}