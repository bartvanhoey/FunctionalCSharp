﻿using FluentAssertions;
using static FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2ExpressYourself.MySingleton;

namespace FunctionalCSharp.Tests.Courses.FunctionalProgrammingWithCSharp.Module2ExpressYourself
{
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
            
            isMySingletonEqual.Should().BeTrue();
            strInstance1.Should().Be(strInstance2);
        }
    }
}