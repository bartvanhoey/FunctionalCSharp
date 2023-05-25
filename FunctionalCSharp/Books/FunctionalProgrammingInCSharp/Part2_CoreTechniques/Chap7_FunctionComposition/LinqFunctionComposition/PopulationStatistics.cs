namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.LinqFunctionComposition
{
    public static class PopulationStatistics
    {
        public static decimal AverageEarningsOfRichestQuartile(List<RichPerson> population) =>
            population
                .OrderByDescending(p => p.Earnings)
                .Take(population.Count / 4)
                .Select(p => p.Earnings)
                .Average();


        public static IEnumerable<RichPerson> RichestQuartile(this List<RichPerson> population)
            => population.OrderByDescending(p => p.Earnings).Take(population.Count / 4);

        
        public static decimal AverageEarnings(this IEnumerable<RichPerson> population) =>
            population.Select(p => p.Earnings)
                .Average();


    }
}