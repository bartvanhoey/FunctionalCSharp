using System.Net.Mail;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Model
{
    public class EmailGateway : IEmailGateway
    {
        public bool SendPromotionNotification(string email, CustomerStatus newStatus) 
            => SendEmail(email, "Congratulations!", "You've been promoted to " + newStatus);

        private bool SendEmail(string to, string subject, string body)
        {
            using var client = new SmtpClient();
            try
            {
                client.Send(new MailMessage("noreply@northwind.com", to, subject, body));
                return true;
            }
            catch (SmtpException)
            {
                return false;
            }
        }
    }
}