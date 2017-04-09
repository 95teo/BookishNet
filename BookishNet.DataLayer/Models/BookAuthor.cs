using System.ComponentModel.DataAnnotations.Schema;

namespace BookishNet.DataLayer.Models
{
    public class BookAuthor
    {
        [ForeignKey("BookId")]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}