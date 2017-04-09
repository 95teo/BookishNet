using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookishNet.DataLayer.Models;

namespace BookishNet.DataLayer.GenericModels
{
    public class Person
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Address { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}