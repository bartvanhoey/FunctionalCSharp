using FunctionalCSharp.Functional;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel
{
    public interface IEmailGateway
    {
        Result SendPromotionNotification(string email, CustomerStatus newStatus);
    }
}