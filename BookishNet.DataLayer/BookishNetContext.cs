using BookishNet.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BookishNet.DataLayer
{
    public class BookishNetContext : DbContext
    {
        private const string ConnectionString =
            @"Server=(localdb)\mssqllocaldb;
             Database=BookishNet;
             Trusted_Connection=True";

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(x => new {x.BookId, x.AuthorId});

            modelBuilder.Entity<Message>()
                .HasKey(m => new {m.SenderId, m.ReceiverId});

            modelBuilder.Entity<Book>()
                .HasOne(b => b.User)
                .WithMany(l => l.BorrowedBooks)
                .HasForeignKey(b => b.BorrowerId)
                ;

            modelBuilder.Entity<Book>()
                .HasOne(b => b.User1)
                .WithMany(l => l.LoanedBooks)
                .HasForeignKey(b => b.LoanerId);
        }
    }
}