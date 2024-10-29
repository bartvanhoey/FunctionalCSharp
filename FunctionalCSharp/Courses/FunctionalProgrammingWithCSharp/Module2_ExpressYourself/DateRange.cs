namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2_ExpressYourself;

public class DateRange
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool DateIsInRange(DateTime checkDate) => Start.CompareTo(checkDate) <= 0 && End.CompareTo(checkDate) >= 0;
}