using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookishNet.DataLayer.Migrations
{
    public partial class RemovedAuthorsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_BookAuthor_Authors_AuthorId",
                "BookAuthor");

            migrationBuilder.DropTable(
                "Authors");

            migrationBuilder.AddColumn<string>(
                "PenName",
                "Users",
                nullable: true);

            migrationBuilder.AddForeignKey(
                "FK_BookAuthor_Users_AuthorId",
                "BookAuthor",
                "AuthorId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_BookAuthor_Users_AuthorId",
                "BookAuthor");

            migrationBuilder.DropColumn(
                "PenName",
                "Users");

            migrationBuilder.CreateTable(
                "Authors",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PenName = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    SecondName = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        "FK_Authors_Roles_RoleId",
                        x => x.RoleId,
                        "Roles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Authors_RoleId",
                "Authors",
                "RoleId");

            migrationBuilder.AddForeignKey(
                "FK_BookAuthor_Authors_AuthorId",
                "BookAuthor",
                "AuthorId",
                "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}