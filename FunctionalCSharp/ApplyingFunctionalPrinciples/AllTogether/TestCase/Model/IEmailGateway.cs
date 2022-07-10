namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Model
{
    public interface IEmailGateway
    {
        bool SendPromotionNotification(string email, CustomerStatus newStatus);
    }
}
