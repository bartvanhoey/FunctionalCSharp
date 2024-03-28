using FluentAssertions;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.OptionoClass;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;
using Shouldly;
using static System.Console;
using static FunctionalCSharp.MyYumba.Y;

Chap6AgeReader.StartProgram();


var optiono = MyInt.Parse("hello world");
var match = optiono.YMatch(() => "no value" , x => x.ToString());
match.ShouldBe("no value");

var optiono123456 = MyInt.Parse("123456");
var match123456 = optiono123456.YMatch(() => "no value" , x => x.ToString());
match123456.ShouldBe("123456");

IndexerIdiosyncrasy.WriteColorToScreen();

IndexerLookupReturnsOption.WriteColorToScreen();

OptionoUseCases.OptionoGreet(Nono);

var sorryWho = OptionoUseCases.OptionoGreet(Nono);
sorryWho.Should().Be("Sorry, Who?");

var helloJohn = OptionoUseCases.OptionoGreet(Somo("John"));
helloJohn.Should().Be("Hello, John");

// you CANNOT assign null here
// var helloNull = OptionoUseCases.OptionoGreetMatch(MySome(null));

var helloJohnImplicit = OptionoUseCases.OptionoGreet("John");
helloJohnImplicit.Should().Be("Hello, John");





ReadKey();



































// FirstClass.Go();

// ExpressionsVsStatements.Go();

// var chap05 = new Chap05();
// chap05.MethodChaining();
// chap05.CompositionInElevatedWorld();
// chap05.CalculateAverage();