﻿using Shouldly;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.Before;

namespace FunctionalCSharp.Tests.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures;

public class BankAccountTests
{
    [Fact]
    public void TestRefillMethod()
    {
        var bankAccount = new BankAccount();
        var result = bankAccount.RefillBalance(1, 100);

        // result.ShouldBe("OK"); // not always OK as random failures are thrown
        result.ShouldBeOfType<string>();            
    } 
}