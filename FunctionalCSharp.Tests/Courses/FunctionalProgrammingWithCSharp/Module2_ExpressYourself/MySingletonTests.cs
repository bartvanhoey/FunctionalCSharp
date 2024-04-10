using Shouldly;
using static FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2_ExpressYourself.MySingleton;

namespace FunctionalCSharp.Tests.Courses.FunctionalProgrammingWithCSharp.Module2_ExpressYourself;

public class MySingletonTests
{
    [Fact]
    public void MySingletonShouldOnlyInstantiatedOnce()
    {
        var instance1 = MySingletonInstance;
        var instance2 = MySingletonInstance;

        var isMySingletonEqual = ReferenceEquals(instance1,instance2);

        var strInstance1 = instance1.ToString();
        var strInstance2 = instance1.ToString();
            
        isMySingletonEqual.ShouldBeTrue();
        strInstance1.ShouldBe(strInstance2);
    }
}