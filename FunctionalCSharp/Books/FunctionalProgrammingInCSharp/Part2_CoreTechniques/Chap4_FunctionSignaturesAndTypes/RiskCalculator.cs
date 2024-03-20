using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes.CustomType;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes;

public static class RiskCalculator
{
    // public static Risk CalculateRisk(int age) => age.Value < 60 ? Risk.Low : Risk.High;
    // Because CalculateRisk takes a Custom Type (Value Object) it is impossible to enter an invalid age as parameter
    // in this way you don't need to make validations inside the method anymore, as Age will always be a correct age
    
    // advantages of using a Custom Type (Value Object)
    // * only valid age values can be given
    // * CalculateRiskProfile no longer causes run-time errors
    // * validating age is captured in the Creation of an Age object => removes Age Validation Duplication
    public static Risk CalculateRiskProfile(Age age) => age < 60 ? Risk.Low : Risk.Medium;
}