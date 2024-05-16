using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Models;
using FunctionalCSharp.MyYumba;
using static FunctionalCSharp.MyYumba.Y;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling;

// Recruit Candidate Option Style
public static class RecruitCandidateOptionStyle
{
    public static YOption<Candidate> Recruit(Candidate candidate) 
        => YSome(candidate).YWhere(IsEligible).YBind(TechTest).YBind(Interview);

    private static bool IsEligible(Candidate candidate) => candidate.Age > 22;
    private static YOption<Candidate> TechTest(Candidate candidate)
        => candidate.HasUniversityDegree ? YSome(candidate) : YNone;

    private static YOption<Candidate> Interview(Candidate candidate)
        => candidate is { HasUniversityDegree: true, Age: < 50 } ? YSome(candidate) : YNone;


}