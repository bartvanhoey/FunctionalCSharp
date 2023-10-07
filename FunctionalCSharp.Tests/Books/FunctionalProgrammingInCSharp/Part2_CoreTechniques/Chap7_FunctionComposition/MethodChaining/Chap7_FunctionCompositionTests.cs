using FluentAssertions;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.MethodChaining;
using LaYumba.Functional;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.MethodChaining.FunctionCompC1;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.MethodChaining
{
    public class Chap7FunctionCompositionTests
    {

        [Fact]
        public void Test_Chap07FunctionComp01_ElevatedWorld()
        {
            var person = new PersonC7("Bart", "Van Hoey");

            var opt = F.Some(person);

            var option = opt.Map(GenerateEmail);

            var email = option.Match(None: () => "none", Some: x => x);
            email.Should().Be("bava@manning.com");
        }
        
        [Fact]
        public void Test_Chap07FunctionComp01_ElevatedWorld_2()
        {
            var person = new PersonC7("Bart", "Van Hoey");

            var opt = F.Some(person);

            var option = opt.Map(ExtensionsC7.AbbreviateName).Map(ExtensionsC7.AddDomain);

            var email = option.Match(None: () => "none", Some: x => x);
            email.Should().Be("bava@manning.com");
        }
        

        
        [Fact]
        public void Test_Chap07FunctionComp01_EmailFor()
        {
            var person = new PersonC7("Bart", "Van Hoey");
            var email = GenerateEmail(person);

            email.Should().Be("bava@manning.com");
        }
        
        [Fact]
        public void Test_Chap07FunctionComp01_MethodChaining()
        {
            var person = new PersonC7("Bart", "Van Hoey");

            var email = person.AbbreviateName().AddDomain();
            email.Should().Be("bava@manning.com");
        }
        
        
        
    }



}