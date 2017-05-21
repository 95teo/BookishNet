using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookishNet.DataLayer.Models
{
    public class UserLoanedBooksHistory
    {
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }

        public int LoanerId { get; set; }

        [ForeignKey("LoanerId")]
        public User User { get; set; }

        public int BorrowerId { get; set; }

        [ForeignKey("BorrowerId")]
        public User User1 { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
    }
}