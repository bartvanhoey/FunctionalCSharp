namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Models
{
    public class AuditEntry
    {
        public int Number { get; }
        public string VisitorName { get; }
        public DateTime TimeOfVisit { get; }

        public AuditEntry(int number, string visitorName, DateTime timeOfVisit)
        {
            Number = number;
            VisitorName = visitorName;
            TimeOfVisit = timeOfVisit;
        }
    }
}