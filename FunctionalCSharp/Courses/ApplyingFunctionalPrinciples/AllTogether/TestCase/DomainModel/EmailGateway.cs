using System.Net.Mail;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors;
using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel
{
    public class EmailGateway : IEmailGateway
    {
        public Result SendPromotionNotification(string email, CustomerStatus newStatus)
        {
            return SendEmail(email, "Congratulations!", "You've been promoted to " + newStatus);
        }

        private Result SendEmail(string to, string subject, string body)
        {
            using var client = new SmtpClient();
            try
            {
                client.Send(new MailMessage("noreply@northwind.com", to, subject, body));
                return Result.Ok();
            }
            catch (SmtpException)
            {
                return Result.Fail(new UnableToSendEmailError());
            }
        }
    }
}