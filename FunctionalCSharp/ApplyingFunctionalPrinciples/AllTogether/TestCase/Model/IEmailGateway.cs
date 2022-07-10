namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Model
{
    public interface IEmailGateway
    {
        void SendPromotionNotification(string email, CustomerStatus newStatus);
    }
}
