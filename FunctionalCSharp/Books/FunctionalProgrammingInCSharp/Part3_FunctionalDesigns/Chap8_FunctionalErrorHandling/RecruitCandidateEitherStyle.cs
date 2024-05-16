using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Models;
using FunctionalCSharp.MyYumba;
using static FunctionalCSharp.MyYumba.Y;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling;

// Recruit Candidate Either Style
public static class RecruitCandidateEitherStyle
{
    public static YEither<Rejection, Candidate> Recruit(this Candidate candidate)
        => YRight(candidate)
            .YBind(CheckEligibility)
            .YBind(CheckCanTakeTechTest)
            .YBind(CheckCanTakeInterview);
   
    private static YEither<Rejection, Candidate> CheckEligibility(Candidate candidate)
        => candidate.Age > 22 ? candidate : new Rejection("Candidate is too young");

    private static YEither<Rejection, Candidate> CheckCanTakeTechTest(Candidate candidate)
        => candidate.HasUniversityDegree ? YRight(candidate) : YLeft(new Rejection("Candidate has no university degree"));

    private static YEither<Rejection, Candidate> CheckCanTakeInterview(Candidate candidate)
        => candidate is { HasUniversityDegree: true, Age: < 50 }
            ? YRight(candidate)
            : new Rejection("Candidate is too old for interview");
}