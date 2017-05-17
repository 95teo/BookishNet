namespace BookishNet.Mvc.Models
{
    public class Email
    {
        public string Username { get; set; }

        public string Sender { get; set; }

        public string Receiver { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}