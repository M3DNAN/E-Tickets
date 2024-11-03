
using System.Net.Mail;
using System.Net;

namespace E_Tickets.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("alroubimustafa@gmail.com", "tyla nout escw efxf")
            };

            return client.SendMailAsync(
                new MailMessage(from: "alroubimustafa@gmail.com",
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
