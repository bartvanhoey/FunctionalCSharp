using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes;
// int -> string                                    |   Func<int, string>                       |   (int i) => i.ToString()
// () -> string                                     |   Func<string>                            |   () => "Hello"
// int -> ()                                        |   Action<int>                             |   (int i) => Writeline($"Gimme {i}")
// () -> ()                                         |   Action                                  |   () => Writeline("Hello World")
// (int, int) -> int                                |   Func<int,int,int>                       |   (int a, int b) => a + b

// (string, (IDbConnection -> T)) -> T              |   Func<string, Func<IDbConnection,T>, T>  |
// (IEnumerable<T>, (T -> bool)) -> IEnumerable<T>                                              |   Enumerable.Where
// (IEnumerable<A>, IEnumerable<B>, ((A, B) -> C)) -> IEnumerable<C> En                         |   Enumerable.Zip

public class Chap4
{
    public Option<string> OptionTestMethod(string value) => value;
}