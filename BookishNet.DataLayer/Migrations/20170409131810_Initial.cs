using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookishNet.DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Genres",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Genres", x => x.Id); });

            migrationBuilder.CreateTable(
                "Roles",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Roles", x => x.Id); });

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

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    SecondName = table.Column<string>(nullable: true),
                    Stars = table.Column<double>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        "FK_Users_Roles_RoleId",
                        x => x.RoleId,
                        "Roles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Books",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorName = table.Column<string>(nullable: false),
                    BorrowerId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GenreId = table.Column<int>(nullable: true),
                    IsBorrowed = table.Column<bool>(nullable: false),
                    LoanerId = table.Column<int>(nullable: false),
                    PublishingYear = table.Column<int>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        "FK_Books_Users_BorrowerId",
                        x => x.BorrowerId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Books_Genres_GenreId",
                        x => x.GenreId,
                        "Genres",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Books_Users_LoanerId",
                        x => x.LoanerId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Messages",
                table => new
                {
                    SenderId = table.Column<int>(nullable: false),
                    ReceiverId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => new {x.SenderId, x.ReceiverId});
                    table.ForeignKey(
                        "FK_Messages_Users_ReceiverId",
                        x => x.ReceiverId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Messages_Users_SenderId",
                        x => x.SenderId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                "BookAuthor",
                table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => new {x.BookId, x.AuthorId});
                    table.ForeignKey(
                        "FK_BookAuthor_Authors_AuthorId",
                        x => x.AuthorId,
                        "Authors",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_BookAuthor_Books_BookId",
                        x => x.BookId,
                        "Books",
                        "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                "Reviews",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    ReviewText = table.Column<string>(nullable: true),
                    Stars = table.Column<double>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        "FK_Reviews_Books_BookId",
                        x => x.BookId,
                        "Books",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Authors_RoleId",
                "Authors",
                "RoleId");

            migrationBuilder.CreateIndex(
                "IX_Books_BorrowerId",
                "Books",
                "BorrowerId");

            migrationBuilder.CreateIndex(
                "IX_Books_GenreId",
                "Books",
                "GenreId");

            migrationBuilder.CreateIndex(
                "IX_Books_LoanerId",
                "Books",
                "LoanerId");

            migrationBuilder.CreateIndex(
                "IX_BookAuthor_AuthorId",
                "BookAuthor",
                "AuthorId");

            migrationBuilder.CreateIndex(
                "IX_Messages_ReceiverId",
                "Messages",
                "ReceiverId");

            migrationBuilder.CreateIndex(
                "IX_Reviews_BookId",
                "Reviews",
                "BookId");

            migrationBuilder.CreateIndex(
                "IX_Users_RoleId",
                "Users",
                "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "BookAuthor");

            migrationBuilder.DropTable(
                "Messages");

            migrationBuilder.DropTable(
                "Reviews");

            migrationBuilder.DropTable(
                "Authors");

            migrationBuilder.DropTable(
                "Books");

            migrationBuilder.DropTable(
                "Users");

            migrationBuilder.DropTable(
                "Genres");

            migrationBuilder.DropTable(
                "Roles");
        }
    }
}