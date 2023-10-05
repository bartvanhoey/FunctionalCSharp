using FluentAssertions;
using LaYumba.Functional;
using static System.Linq.Enumerable;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap5_DesigningProgramsWithFunctionComposition
{
    public class Chap05
    {
        private readonly Func<Person, string> _emailFor = p => AppendDomain(AbbreviateName(p));
        private static string AbbreviateName(Person p) => Abbreviate(p.FirstName) + Abbreviate(p.LastName);
        private static string AppendDomain(string localPart) => $"{localPart}@manning.com";
        private static string Abbreviate(string s) => s[..2].ToLower();
    
        public void MethodChaining()
        {
            var joe = new Person("Joe", "Blogs");
            var joeEmail = _emailFor(joe);
            var joeEmailFunctional = joe.AbbreviateName().AppendDomain();
        }

        public void CompositionInElevatedWorld()
        {
            var optJoe = F.Some(new Person("Joe", "Smith"));

            var a = optJoe.Map(_emailFor);
            var b = optJoe.Map(AbbreviateName).Map(AppendDomain);
        
            a.Should().Be(b);
        }

        public void CalculateAverage()
        {
            var population =Range(1, 8).Select(i => new Person { Earnings = i * 10000 }).ToList();
            var average1 = population.AverageEarningsOfRichestQuartile();
            var average2 = population.RichestQuartile().AverageEarnings();
        
            average1.Should().Be(average2);
        
        }
    }

    public static class PersonListExtensions
    {
        public static decimal AverageEarnings(this IEnumerable<Person> people) => people.Average(x => x.Earnings);

        public static IEnumerable<Person> RichestQuartile(this IReadOnlyCollection<Person> people) 
            => people.OrderByDescending(p => p.Earnings).Take(people.Count / 4);


    }

    public static class ReadOnlyCollectionExtensions
    {
        public static decimal AverageEarningsOfRichestQuartile(this IReadOnlyCollection<Person> people) 
            => people.OrderByDescending(p => p.Earnings).Take(people.Count / 4).Select(p => p.Earnings).Average();
    
    
    }
}


