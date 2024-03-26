

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Before.Models;

public class Industry : Entity
{
    public const string CarsIndustry = "Cars";
    public const string PharmacyIndustry = "Pharmacy";

    public virtual string Name { get; set; }
}