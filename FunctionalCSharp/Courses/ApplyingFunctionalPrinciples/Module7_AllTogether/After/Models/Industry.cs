using Fupr.Functional.MaybeClass;
using Fupr.Functional.ResultClass;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.ResultErrors.Factory.ErrorFactory;
using static Fupr.Functional.ResultClass.Result;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Models
{
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
            if (maybeIndustryName.HasNoValue) return Fail<Industry>(IndustryNameNotSpecified);
            return maybeIndustryName.Value switch
            {
                "Cars" => Ok(CarsIndustry),
                "Pharmacy" => Ok(PharmaIndustry),
                "Other" => Ok(OtherIndustry),
                _ => Fail<Industry>(IndustryNotSpecified)
            };
        }
    }
}