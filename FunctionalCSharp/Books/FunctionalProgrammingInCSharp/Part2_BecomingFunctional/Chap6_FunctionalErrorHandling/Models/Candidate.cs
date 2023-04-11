namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Models
{
    public class Candidate
    {
        public Candidate(string firstName, string lastName, int age, bool hasUniversityDegree = true)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HasUniversityDegree = hasUniversityDegree;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool HasUniversityDegree { get; set; }
    }
}