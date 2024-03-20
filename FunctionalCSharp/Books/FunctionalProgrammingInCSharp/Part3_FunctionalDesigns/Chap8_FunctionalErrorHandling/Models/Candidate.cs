namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Models;

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