using Shouldly;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.yOptionClass;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;
using static System.Console;
using static FunctionalCSharp.MyYumba.Y;




Chap6AgeReader.StartProgram();

var yOption = MyInt.Parse("hello world");
var match = yOption.YMatch(() => "no value" , x => x.ToString());
match.ShouldBe("no value");

var yOption123456 = MyInt.Parse("123456");
var match123456 = yOption123456.YMatch(() => "no value" , x => x.ToString());
match123456.ShouldBe("123456");

IndexerIdiosyncrasy.WriteColorToScreen();

IndexerLookupReturnsOption.WriteColorToScreen();

yOptionUseCases.yOptionGreet(YNone);

var sorryWho = yOptionUseCases.yOptionGreet(YNone);
sorryWho.ShouldBe("Sorry, Who?");

var helloJohn = yOptionUseCases.yOptionGreet(YSome("John"));
helloJohn.ShouldBe("Hello, John");

// you CANNOT assign null here
// var helloNull = yOptionUseCases.yOptionGreetMatch(MySome(null));

var helloJohnImplicit = yOptionUseCases.yOptionGreet("John");
helloJohnImplicit.ShouldBe("Hello, John");





ReadKey();



































// FirstClass.Go();

// ExpressionsVsStatements.Go();

// var chap05 = new Chap05();
// chap05.MethodChaining();
// chap05.CompositionInElevatedWorld();
// chap05.CalculateAverage();