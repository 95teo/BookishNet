using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookishNet.DataLayer.GenericModels;

namespace BookishNet.DataLayer.Models
{
    public class User : Person
    {
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public double Stars { get; set; }

        public IEnumerable<Book> LoanedBooks { get; set; }
        public IEnumerable<Book> BorrowedBooks { get; set; }
    }
}