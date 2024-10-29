namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2_ExpressYourself;

public class DateRangeFunctional
{
    public DateRangeFunctional(DateTime start, DateTime end)
    {
        if (start.CompareTo(end) >= 0) throw new Exception("Start date cannot be earlier than end date");
        Start = start;
        End = end;
    }

    private DateTime Start { get; }
    private DateTime End { get; }

    public bool DateIsInRange(DateTime checkDate)
        => Start.CompareTo(checkDate) <= 0 && End.CompareTo(checkDate) >= 0;

    public DateRangeFunctional Slide(int days)
        => new(Start.AddDays(days), End.AddDays(days));
}