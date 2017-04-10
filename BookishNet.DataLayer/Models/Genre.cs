using System.ComponentModel.DataAnnotations;

namespace BookishNet.DataLayer.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}