using System.ComponentModel.DataAnnotations;

namespace BookishNet.DataLayer.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        public string RoleName { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}