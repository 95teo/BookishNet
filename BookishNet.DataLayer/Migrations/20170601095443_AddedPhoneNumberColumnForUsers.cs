using Microsoft.EntityFrameworkCore.Migrations;

namespace BookishNet.DataLayer.Migrations
{
    public partial class AddedPhoneNumberColumnForUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "Phone",
                "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Phone",
                "Users");
        }
    }
}