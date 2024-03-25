using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes.
    CustomType;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes;

public static class RiskCalculator
{
    // Avoid the use of primitive types (primitive obsession)
    // Because CalculateRisk takes a Custom Type (Value Object) it is impossible to enter an invalid age as parameter
    // in this way you don't need to make validations inside the method anymore, as Age will always be a correct age

    // advantages of using a Custom Type (Value Object)
    // * only valid age values can be given
    // * CalculateRiskProfile no longer causes run-time errors
    // * validating age is captured in the Creation of an Age object => removes Age Validation Duplication
    // * Signature is more explicit ... you know surely know Age is a correct number 
    public static Risk CalculateRiskProfile(AgeChap4 ageChap4) => ageChap4 < 60 ? Risk.Low : Risk.Medium;
    
    // (Age, Gender) -> Risk
    public static Risk CalculateRiskProfile(AgeChap4 ageChap4, Gender gender)
    {
        var threshold = gender == Gender.Female ? 62 : 60;
        return ageChap4 < threshold ? Risk.Low : Risk.Medium;
    }

    // OLD Dishonest method with primitive types as input => dishonest
    public static Risk CalculateRiskProfile(int age)
    {
        if (age is < 0 or >= 120)
            throw new ArgumentException($"{age} is not a valid age");

        return age < 60 ? Risk.Low : Risk.High;
    }
}

public enum Gender
{
    Male,
    Female
}