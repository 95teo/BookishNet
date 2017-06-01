using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BookishNet.DataLayer;

namespace BookishNet.DataLayer.Migrations
{
    [DbContext(typeof(BookishNetContext))]
    [Migration("20170601092852_RemovedAuthorsTable")]
    partial class RemovedAuthorsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookishNet.DataLayer.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorName")
                        .IsRequired();

                    b.Property<int?>("BorrowerId");

                    b.Property<string>("Description");

                    b.Property<int?>("GenreId");

                    b.Property<bool>("IsBorrowed");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LoanerId");

                    b.Property<int>("PublishingYear");

                    b.Property<DateTime>("Timestamp");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("BorrowerId");

                    b.HasIndex("GenreId");

                    b.HasIndex("LoanerId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookishNet.DataLayer.Models.BookAuthor", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("AuthorId");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("BookishNet.DataLayer.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("BookishNet.DataLayer.Models.Message", b =>
                {
                    b.Property<int>("SenderId");

                    b.Property<int>("ReceiverId");

                    b.Property<string>("Content");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("SenderId", "ReceiverId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("BookishNet.DataLayer.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ReviewText");

                    b.Property<double>("Stars");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BookishNet.DataLayer.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("RoleName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BookishNet.DataLayer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PenName");

                    b.Property<int>("RoleId");

                    b.Property<string>("SecondName");

                    b.Property<double>("Stars");

                    b.Property<DateTime>("Timestamp");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookishNet.DataLayer.Models.Book", b =>
                {
                    b.HasOne("BookishNet.DataLayer.Models.User", "User")
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("BorrowerId");

                    b.HasOne("BookishNet.DataLayer.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.HasOne("BookishNet.DataLayer.Models.User", "User1")
                        .WithMany("LoanedBooks")
                        .HasForeignKey("LoanerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookishNet.DataLayer.Models.BookAuthor", b =>
                {
                    b.HasOne("BookishNet.DataLayer.Models.User", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookishNet.DataLayer.Models.Book", "Book")
                        .WithMany("Authors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookishNet.DataLayer.Models.Message", b =>
                {
                    b.HasOne("BookishNet.DataLayer.Models.User", "User1")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookishNet.DataLayer.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookishNet.DataLayer.Models.Review", b =>
                {
                    b.HasOne("BookishNet.DataLayer.Models.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookishNet.DataLayer.Models.User", b =>
                {
                    b.HasOne("BookishNet.DataLayer.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
