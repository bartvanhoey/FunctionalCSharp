namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Models;

public static class CreateCustomerModelExtensions
{
    // public static Result<Maybe<Email?>> GetSecondaryEmail(this CreateCustomerModel? model) =>
    //     model?.SecondaryEmail == null 
    //         ? Result.Success(<Maybe<Email?>>(null))  : 
    //         Email.CreateEmail(model.SecondaryEmail!).Map(email => (Maybe<Email?>)email);
}