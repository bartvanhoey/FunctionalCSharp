using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Models;
using FunctionalCSharp.MyYumba;
using Shouldly;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.
    RecruitCandidateEitherStyle;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.
    Chap8_FunctionalErrorHandling;

public class RecruitCandidateEitherStyleTests
{
    [Theory]
    [InlineData("tom", "jones", 20, true, "Candidate is too young")]
    [InlineData("tim", "Brookes", 66, true, "Candidate is too old for interview")]
    [InlineData("Sharon", "Stone", 35, false, "Candidate has no university degree")]
    [InlineData("Kim", "Basinger", 35, true, "Candidate Kim Basinger can be recruited")]
    public void Test_Recruit_Candidate_Either_Style(string firstName, string lastName, int age, bool hasUniDegree,
        string reason) => new Candidate(firstName, lastName, age, hasUniDegree).Recruit().Result().ShouldBe(reason);
}

public static class EitherExtensions
{
    public static string Result(this YEither<Rejection, Candidate> candidate)
        => candidate.YMatch(l => l.Reason, r => $"Candidate {r.FirstName} {r.LastName} can be recruited");
}