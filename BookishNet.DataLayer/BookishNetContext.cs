using BookishNet.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BookishNet.DataLayer
{
    public class BookishNetContext : DbContext
    {
        private const string ConnectionString =
            @"Server=tcp:bookishsnet.database.windows.net,1433;Initial Catalog=BookishNet;Persist Security Info=False;User ID=teo;Password=Informatica1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<User> Users { get; set; }

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