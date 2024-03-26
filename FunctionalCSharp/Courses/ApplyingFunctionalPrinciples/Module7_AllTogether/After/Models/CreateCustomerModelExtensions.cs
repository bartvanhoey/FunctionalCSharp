using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.ValueObjects;
using Fupr.Functional.MaybeClass;
using Fupr.Functional.ResultClass;
using Fupr.Functional.ResultClass.Extensions;
using static Fupr.Functional.ResultClass.Result;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Models;

public static class CreateCustomerModelExtensions
{
    public static Result<Maybe<Email?>> GetSecondaryEmail(this CreateCustomerModel? model) =>
        model?.SecondaryEmail == null 
            ? Ok<Maybe<Email?>>(null) : 
            Email.CreateEmail(model.SecondaryEmail!).Map(email => (Maybe<Email?>)email);
}