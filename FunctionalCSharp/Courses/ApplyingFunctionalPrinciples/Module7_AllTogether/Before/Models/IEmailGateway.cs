namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Before.Models
{
    public interface IEmailGateway
    {
        void SendPromotionNotification(string email, CustomerStatus newStatus);
    }
}