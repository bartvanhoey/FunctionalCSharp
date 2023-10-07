using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors;
using FunctionalCSharp.Functional.MaybeClass;
using FunctionalCSharp.Functional.ResultClass;
using static FunctionalCSharp.Functional.ResultClass.Result;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Models
{
    public class Industry : Entity
    {
        public static readonly Industry Cars = new(1, "Cars");
        public static readonly Industry Pharmacy = new(2, "Pharmacy");
        public static readonly Industry Other = new(3, "Other");
        public virtual string Name { get; set; }

        public Industry(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Result<Industry> GetIndustry(Maybe<string> industryName)
        {
            if (industryName.HasNoValue) return Fail<Industry>(new IndustryNameIsRequiredResultError());
            if (industryName.Value == Cars.Name) return Ok(Cars);
            if (industryName.Value == Pharmacy.Name) return Ok(Pharmacy);
            return industryName.Value == Other.Name 
                ? Ok(Other) 
                : Fail<Industry>(new IndustryNameIsInvalidResultError(industryName.Value));
        }
    }

}