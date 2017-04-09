using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookishNet.DataLayer.Models
{
    public class Review
    {
        public int Id { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public string ReviewText { get; set; }

        public double Stars { get; set; }
    }
}