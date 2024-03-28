namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes;

public static class RiskCalculatorChap4
{
    // Avoid the use of primitive types (primitive obsession)
    // Because CalculateRisk takes a Custom Type (Value Object) it is impossible to enter an invalid age as parameter
    // in this way you don't need to make validations inside the method anymore, as Age will always be a correct age

    // advantages of using a Custom Type (Value Object)
    // * only valid age values can be given
    // * CalculateRiskProfile no longer causes run-time errors
    // * validating age is captured in the Creation of an Age object => removes Age Validation Duplication
    // * Signature is more explicit ... you know surely know Age is a correct number 
    public static RiskChap4 CalculateRiskProfileChap4(Chap4Age chap4Age) => chap4Age < 60 ? RiskChap4.Low : RiskChap4.Medium;
    
    // (Age, Gender) -> Risk
    public static RiskChap4 CalculateRiskProfileChap4(Chap4Age chap4Age, GenderChap4 genderChap4)
    {
        var threshold = genderChap4 == GenderChap4.Female ? 62 : 60;
        return chap4Age < threshold ? RiskChap4.Low : RiskChap4.Medium;
    }

    // OLD Dishonest method with primitive types as input => dishonest
    public static RiskChap4 CalculateRiskProfileChap4(int age)
    {
        if (age is < 0 or >= 120)
            throw new ArgumentException($"{age} is not a valid age");

        return age < 60 ? RiskChap4.Low : RiskChap4.High;
    }
}