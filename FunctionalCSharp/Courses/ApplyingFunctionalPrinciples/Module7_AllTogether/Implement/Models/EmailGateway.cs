using System.Net.Mail;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors;
using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Models
{
    public class EmailGateway : IEmailGateway
    {
        public Result SendPromotionNotification(string email, CustomerStatus newStatus)
        {
           return SendEmail(email, "Congratulations!", "You've been promoted to " + newStatus);
        }

        private Result SendEmail(string to, string subject, string body)
        {
            var message = new MailMessage("noreply@northwind.com", to, subject, body);
            using var client = new SmtpClient();
            try
            {
                client.Send(message);
                return Result.Ok();
            }
            catch (SmtpException)
            {
                return Result.Fail(new UnableToSendEmailResultError());
            }
        }
    }
}