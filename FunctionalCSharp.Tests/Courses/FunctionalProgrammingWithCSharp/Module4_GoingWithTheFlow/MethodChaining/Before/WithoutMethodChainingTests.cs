using FluentAssertions;
using static FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module4GoingWithTheFlow.MethodChaining.Without.
    WithoutMethodChaining;

namespace FunctionalCSharp.Tests.Courses.FunctionalProgrammingWithCSharp.Module4_GoingWithTheFlow.MethodChaining.Before;

public class WithoutMethodChainingTests
{
    [Fact]
    public void GetSelectBoxWithoutMethodChaining_Should_Return_Correct_SelectBox()
    {
        var selectBox = GetSelectBoxWithoutMethodChaining();

        selectBox.Should().NotBeEmpty();
        selectBox.Should().Be(SelectBox);
    }

    private const string SelectBox = "<select id=\"theDoctors\" name=\"theDoctors\">\r\n" +
                                     "\t<option>Unknown</option>\r\n" +
                                     "\t<option value=\"0\">Hartnell</option>\r\n" +
                                     "\t<option value=\"1\">Troughton</option>\r\n" +
                                     "\t<option value=\"2\">Pertwee</option>\r\n" +
                                     "\t<option value=\"3\">T. Baker</option>\r\n" +
                                     "\t<option value=\"4\">Davison</option>\r\n" +
                                     "\t<option value=\"5\">C. Baker</option>\r\n" +
                                     "\t<option value=\"6\">McCoy</option>\r\n" +
                                     "\t<option value=\"7\">McGann</option>\r\n" +
                                     "\t<option value=\"8\">Hurt</option>\r\n" +
                                     "\t<option value=\"9\">Eccleston</option>\r\n" +
                                     "\t<option value=\"10\">Tennant</option>\r\n" +
                                     "\t<option value=\"11\">Smith</option>\r\n" +
                                     "\t<option value=\"12\">Capaldi</option>\r\n" +
                                     "</select>";
}