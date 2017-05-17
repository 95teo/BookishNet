using BookishNet.Mvc.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookishNet.Mvc.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        [HttpPost]
        public void SendEmail([FromBody] Email email)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(email.Username, email.Sender));
            emailMessage.To.Add(new MailboxAddress("", email.Receiver));
            emailMessage.Subject = email.Subject;
            emailMessage.Body = new TextPart("plain") {Text = email.Body};

            using (var client = new SmtpClient())
            {
                //client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 587, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                //TODO: remove this hardcoded email and password
                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("NTTWorkNETProfessional@gmail.com", "passwordfornttinternship");

                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}