namespace BookishNet.Mvc.Tests.DTO
{
    internal class RegisterDto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Birthday { get; set; }

        public bool IsAuthor { get; set; }
    }
}