namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap2_ThinkingInFunctions;

public class Chap02
{
    public IEnumerable<DayOfWeek>? GetDaysStartingWith(string startsWith)
    {
        var dayOfWeeks = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();
        var result = dayOfWeeks
            .Where(d => d.ToString().StartsWith(startsWith));
        var daysStartingWith = result.ToList();
        return daysStartingWith.Any() ? daysStartingWith : null;
    }
}