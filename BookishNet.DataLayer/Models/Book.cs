using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookishNet.DataLayer.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AuthorName { get; set; }

        public int PublishingYear { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public int? GenreId { get; set; }

        public Genre Genre { get; set; }

        public bool IsBorrowed { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public int LoanerId { get; set; }

        public User User { get; set; }

        public int? BorrowerId { get; set; }

        public User User1 { get; set; }

        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<BookAuthor> Authors { get; set; }
    }
}