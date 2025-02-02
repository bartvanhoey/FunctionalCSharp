using Shouldly;
using LaYumba.Functional;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public class ApplePieMakingTests
{
    [Fact]
    public void ApplePieMaking_Map_Example()
    {
        var makePies = (Apples apples) => new ApplePie(apples);

        var someApples = F.Some(new Apples());
        Option<Apples> noneApples = F.None;

        var somePie = someApples.Map(makePies);
        var nonePie = noneApples.Map(makePies);

        var someApplePie = somePie.Match(() => null!, x => x);
        someApplePie.ShouldBeOfType<ApplePie>();
        // someApples.ShouldNotBeNull();
        
        var noneApplePie = nonePie.Match(() => null!, x => x);
        // noneApplePie.GetType().ShouldBe<ApplePie>(); // throws an exception because is null
        noneApplePie.ShouldBeNull();
    }

    private record Apples;
    private record ApplePie(Apples Apples);
}