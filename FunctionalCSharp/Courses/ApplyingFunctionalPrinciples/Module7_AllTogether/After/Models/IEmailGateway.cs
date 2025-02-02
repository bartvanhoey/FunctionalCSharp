

using CSharpFunctionalExtensions;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Models;

public interface IEmailGateway
{
    Result SendPromotionNotification(string email, CustomerStatus newStatus);
}