using FluentAssertions;
using FluentNHibernate.MappingModel.Collections;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.MyOption;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_FunctionalErrorHandling;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Controllers.BookTransfers;
using static System.Console;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.MyOption.MyF;


IndexerIdiosyncrasy.WriteColorToScreen();

MyOptionUseCases.MyOptionGreetMatch(new MyNone<string>());

var sorryWho = MyOptionUseCases.MyOptionGreetMatch(MyNone);
sorryWho.Should().Be("Sorry, Who?");

var helloJohn = MyOptionUseCases.MyOptionGreetMatch(MySome("John"));
helloJohn.Should().Be("Hello, John");

// you CANNOT assign null here
// var helloNull = MyOptionUseCases.MyOptionGreetMatch(MySome(null));

var helloJohnImplicit = MyOptionUseCases.MyOptionGreetMatch("John");
helloJohnImplicit.Should().Be("Hello, John");



var chap06 = new Chap06();
//
// var right = F.Right(12d);
// var left = F.Left("oops");

// chap06.Render(right).Dump();
// chap06.Render(left).Dump();

// var either = chap06.Calc(3,0);
// var either = chap06.Calc(3,2);
//var either = chap06.Calc(-3,3);

// either.RenderToString().Dump();

// var kidEither = either.MyMap(x => chap06.CreateKid(x));

// var kid = kidEither.Match<Kid?>( left: l => null, x => x );

// chap06.Render(kid).Dump();

//
// var candidateBart = new Candidate("Bart", "Van Hoey", 51);
// var recruitOpt = chap06.Recruit(candidateBart);
//
// var recruitEither = chap06.RecruitByEither(candidateBart);

var bookTransferController = new Chapter06BookTransferController();
// var either = controller.Handle(new BookTransfer("OSDDDEBBXXX", DateTime.Now.AddDays(5)));
// var exceptional = bookTransferController.SaveBookTransfer(new BookTransfer("ddd", DateTime.Now));

// var controller = new Chapter06Controller(new InstrumentService());
// var instrumentDetails = controller.GetInstrumentDetails("AAPOP");

var bookTransfer = new BookTransfer("OSDDDEBBXXX", DateTime.Now.AddDays(5));

// var validation = bookTransferController.BookTransfer1();


ReadKey();



































// FirstClass.Go();

// ExpressionsVsStatements.Go();

// var chap05 = new Chap05();
// chap05.MethodChaining();
// chap05.CompositionInElevatedWorld();
// chap05.CalculateAverage();