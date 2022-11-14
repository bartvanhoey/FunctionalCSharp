namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Start.Models
{
    public interface IEmailGateway
    {
        void SendPromotionNotification(string email, CustomerStatus newStatus);
    }
}