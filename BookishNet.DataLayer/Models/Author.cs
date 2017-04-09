using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookishNet.DataLayer.GenericModels;

namespace BookishNet.DataLayer.Models
{
    public class Author : Person
    {
        public int Id { get; set; }

        public string PenName { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public IEnumerable<BookAuthor> Books { get; set; }
    }
}