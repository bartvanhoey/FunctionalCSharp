using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap5_DesigningProgramsWithFunctionComposition;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling;
using FunctionalCSharp.Courses.BeginningFunctionalProgramming;
using LaYumba.Functional;

var chap06 = new Chap06();

var right = F.Right(12d);
var resultValid = chap06.Render(right);

var leftWrong = F.Left("oops");
var resultInvalid = chap06.Render(leftWrong);

var calc1 = chap06.Calculate(3,0);
var calc2 = chap06.Calculate(-3,3);
var calc3 = chap06.Calculate(-3,-3);

Console.ReadKey();

// FirstClass.Go();

// ExpressionsVsStatements.Go();

// var chap05 = new Chap05();
// chap05.MethodChaining();
// chap05.CompositionInElevatedWorld();
// chap05.CalculateAverage();