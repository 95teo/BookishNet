using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookishNet.DataLayer.Models
{
    public class Message
    {
        public int SenderId { get; set; }

        [ForeignKey("SenderId")]
        public User User { get; set; }


        public int ReceiverId { get; set; }

        [ForeignKey("ReceiverId")]
        public User User1 { get; set; }

        public string Content { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}