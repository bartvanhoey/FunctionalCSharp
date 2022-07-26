using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel
{
    public interface IEmailGateway
    {
        Result SendPromotionNotification(string email, CustomerStatus newStatus);
    }
}