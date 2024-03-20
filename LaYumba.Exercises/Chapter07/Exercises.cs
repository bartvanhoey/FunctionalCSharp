using LaYumba.Exercises.Chapter06;

namespace LaYumba.Exercises.Chapter07;

public static class ChapExercises
{
   // 1. Without looking at any code or documentation (or intllisense), write the function signatures of
   // `OrderByDescending`, `Take` and `Average`, which we used to implement `AverageEarningsOfRichestQuartile`:
   static decimal AverageEarningsOfRichestQuartile(List<Person> population)
      => population
         .OrderByDescending(p => p.Earnings)
         .Take(population.Count/4)
         .Select(p => p.Earnings)
         .Average();

   // 2 Check your answer with the MSDN documentation: https://docs.microsoft.com/
   // en-us/dotnet/api/system.linq.enumerable. How is Average different?

   // 3 Implement a general purpose Compose function that takes two unary functions
   // and returns the composition of the two.
}