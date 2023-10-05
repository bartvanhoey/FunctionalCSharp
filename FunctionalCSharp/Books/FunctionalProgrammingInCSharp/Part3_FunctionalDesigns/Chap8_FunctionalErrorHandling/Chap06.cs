using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Models;
using LaYumba.Functional;
using static System.Math;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling
{
    public class Chap06
    {
        // Recruit Candidate Option Style
        public Option<Candidate> Recruit(Candidate candidate) 
            => F.Some(candidate).Where(IsEligible).Bind(TechTest).Bind(Interview);

    
        private static bool IsEligible(Candidate candidate) => candidate.Age > 22;

        private static Option<Candidate> TechTest(Candidate candidate) 
            => candidate.HasUniversityDegree ? F.Some(candidate) : F.None;

        private static Option<Candidate> Interview(Candidate candidate) 
            => candidate is { HasUniversityDegree: true, Age: < 50 } ? F.Some(candidate) : F.None;
    
    
        // Recruit Candidate Either Style
    
        public Either<Rejection, Candidate> RecruitByEither(Candidate candidate) 
            => F.Right(candidate).Bind(CheckEligibility).Bind(TakeTechTest).Bind(TakeInterview);
    
        private static Either<Rejection,Candidate> CheckEligibility(Candidate candidate) 
            => candidate.Age > 22 ? candidate : new Rejection("too young!");
    
        private static Either<Rejection,Candidate> TakeTechTest(Candidate candidate) 
            => candidate.HasUniversityDegree ? F.Right(candidate) : F.Left(new Rejection("No University degree"));

        private static Either<Rejection, Candidate> TakeInterview(Candidate candidate) 
            => candidate is { HasUniversityDegree: true, Age: < 50 } ? F.Right(candidate) : new Rejection("Candidate is too old for interview");


        public Kid CreateKid(double age) => new Kid((int)age, null, null);

        public Either<string, double> Calc(double x, double y)
        {
            if (y == 0) return "Division by zero";
            if (x != 0 && Sign(x) != Sign(y)) return "x / y cannot be negative";
            return Sqrt(x / y);
        }
    }
}