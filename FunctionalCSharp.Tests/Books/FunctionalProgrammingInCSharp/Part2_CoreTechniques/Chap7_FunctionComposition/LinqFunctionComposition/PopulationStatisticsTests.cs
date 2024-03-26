using FluentAssertions;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.LinqFunctionComposition;
using static System.Linq.Enumerable;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.LinqFunctionComposition.PopulationStatistics;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.LinqFunctionComposition;

public class PopulationStatisticsTests
{
    [Fact]
    public void Test_Method_AverageEarningsOfRichestQuartile() 
        => AverageEarningsOfRichestQuartile(SamplePopulation).Should().Be(75000);

    [Fact]
    public void Test_ExtensionMethod_RichestQuartile() 
        => SamplePopulation.RichestQuartile().Count().Should().Be(2);

    [Fact]
    public void Test_ExtensionMethod_AverageEarnings() 
        => SamplePopulation.AverageEarnings().Should().Be(45000);

    [Fact]
    public void Test_ExtensionMethods_RichestQuartile_AverageEarnings() 
        => SamplePopulation.RichestQuartile().AverageEarnings().Should().Be(75000);

    private static List<RichPerson> SamplePopulation
        => Range(1, 8)
            .Select(i => new RichPerson(Earnings: i * 10000))
            .ToList();
            
        
}