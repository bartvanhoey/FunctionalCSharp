using System.Net.Mail;
using CSharpFunctionalExtensions;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Models;

public class EmailGateway : IEmailGateway
{
    public Result SendPromotionNotification(string email, CustomerStatus newStatus) 
        => SendEmail(email, "Congratulations!", "You've been promoted to " + newStatus);

    private Result SendEmail(string to, string subject, string body)
    {
        var message = new MailMessage("noreply@northwind.com", to, subject, body);
        using var client = new SmtpClient();
        try
        {
            client.Send(message);
            return Result.Success(true);
        }
        catch (SmtpException smtpException)
        {
            return Result.Failure(smtpException.Message);
        }
    }
}