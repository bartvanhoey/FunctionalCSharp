﻿using CSharpFunctionalExtensions;
using Shouldly;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After;

using static System.String;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After.Email;

namespace FunctionalCSharp.Tests.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession;

public class ConvertPrimitiveTypesInValueObjectsTests
{
    private const string NewEmailAddress = "newemail@hotmail.com";
    private const string InvalidNewEmailAddress = "newemailhotmail.com";
    private const string OldEmailAddress = "oldemail@hotmail.com";
    private const string InvalidOldEmailAddress = "oldemailhotmail.com";

    [Fact]
    public void TestProcessEmailWithPrimitiveObsession()
    {
        var emailProcessor = new EmailProcessor();
        var result = emailProcessor.ProcessEmailWithPrimitiveObsession(OldEmailAddress, NewEmailAddress);
        result.ShouldBe(NewEmailAddress);
    }
        
    [Fact]
    public void TestProcessEmailWithPrimitiveObsession_InvalidNewEmailAddress()
    {
        var emailProcessor = new EmailProcessor();
        var result = emailProcessor.ProcessEmailWithPrimitiveObsession(OldEmailAddress, InvalidNewEmailAddress);
        result.ShouldBe(Empty);
    }
        
    [Fact]
    public void TestProcessEmailWithPrimitiveObsession_InvalidOldEmailAddress()
    {
        var emailProcessor = new EmailProcessor();
        var result = emailProcessor.ProcessEmailWithPrimitiveObsession(InvalidOldEmailAddress, NewEmailAddress);
        result.ShouldBe(Empty);
    }
        
    [Fact]
    public void TestProcessEmailWithValueObjects()
    {
        var processor = new EmailProcessor();
            
        var oldMail = Create(OldEmailAddress);
        var newMail = Create(NewEmailAddress);
            
        var result = processor.ProcessEmailWithValueObjects(oldMail, newMail);
        result.ShouldBe(NewEmailAddress);
    }
        
    [Fact]
    public void TestProcessEmailWithValueObjects_WithInvalidNewEmailAddress()
    {
        var processor = new EmailProcessor();
            
        var oldMail = Create(OldEmailAddress);
        var newMail = Create(InvalidNewEmailAddress);
            
        var result = processor.ProcessEmailWithValueObjects(oldMail, newMail);
        result.ShouldBe(Empty);
    }
}

public class EmailProcessor
{

    // with value objects - better approach
    public string ProcessEmailWithValueObjects(Result<Email> oldEmailResult, Result<Email> newEmailResult)
    {
        if (oldEmailResult.IsFailure || newEmailResult.IsFailure) return Empty;
        var customer = GetCustomerByEmail(oldEmailResult.Value);
        customer.Email = newEmailResult.Value;
        return customer.Email;
    }
        
    // with primitive obsession
    public string ProcessEmailWithPrimitiveObsession(string oldEmail, string newEmail)
    {
        var oldEmailResult = Create(oldEmail);
        var newEmailResult = Create(newEmail);

        if (oldEmailResult.IsFailure || newEmailResult.IsFailure) return Empty;

        var oldEmailValue = oldEmailResult.Value;
        var customer = GetCustomerByEmail(oldEmailValue);
        customer.Email = newEmailResult.Value;

        return customer.Email;
    }
        
    private MyCustomer GetCustomerByEmail(string oldEmailValue) => new() {Email = oldEmailValue};

        
}

internal class MyCustomer
{
    public string? Email { get; set; }
}