using FunctionalCSharp.MyYumba;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public static class Chap6RiskCalculator
{
    // Age -> Risk
    private static Chap6Risk CalculateRiskProfileChap6(Chap6Age chap6Age) 
        => chap6Age < 60 ? Chap6Risk.Low : Chap6Risk.Medium;

    public static YOption<Chap6Risk> RiskOf(Chap6Subject subject) 
        => subject.Age.YMap(CalculateRiskProfileChap6);

  
}