using CSharpFunctionalExtensions;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Models;

public class Industry : Entity
{

    public static readonly Industry CarsIndustry = new(1, "Cars");
    public static readonly Industry PharmaIndustry = new(1, "Pharmacy");
    public static readonly Industry OtherIndustry = new(1, "Other");
        
    public virtual string Name { get; protected set; }

    private Industry(int id, string name)
    {
        Name = name;
        Id = id;
    }

    public static Result<Industry> Get(Maybe<string?> maybeIndustryName)
    {
        if (maybeIndustryName.HasNoValue) return Result.Failure<Industry>("Industry not specified");
        return maybeIndustryName.Value switch
        {
            "Cars" => Result.Success(CarsIndustry),
            "Pharmacy" => Result.Success(PharmaIndustry),
            "Other" => Result.Success(OtherIndustry),
            _ => Result.Failure<Industry>("Industry not found")
        };
    }
}