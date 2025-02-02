using Shouldly;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Extensions;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Models;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Models.ActionType;
using static Xunit.Assert;

namespace FunctionalCSharp.Tests.Courses.ApplyingFunctionalPrinciples;

public class AuditManagerTests
{

    [Fact]
    public void AddRecord_adds_a_record_to_an_existing_file_if_not_overflowed()
    {
        var manager = new AuditManager(10);
        var file = new FileContent("Audit_1.txt", new[]
        {
            "1;Peter Peterson;2016-04-06T16:30:00"
        });
             
        var action = manager.AddRecord(file, "Jane Doe", new DateTime(2016, 4, 6, 17, 0, 0));

        Equal(Update, action.Type);
        Equal("Audit_1.txt", action.FileName);
        Equal(new[]
        {
            "1;Peter Peterson;2016-04-06T16:30:00",
            "2;Jane Doe;2016-04-06T17:00:00"
        }, action.Content);
    }

    [Fact]
    public void AddRecord_adds_a_record_to_a_new_file_if_overflowed()
    {
        var manager = new AuditManager(3);
        var file = new FileContent("Audit_1.txt", new[]
        {
            "1;Peter Peterson;2016-04-06T16:30:00",
            "2;Jane Doe;2016-04-06T16:40:00",
            "3;Jack Rich;2016-04-06T17:00:00"
        });

        var action = manager.AddRecord(file, "Tom Tomson", new DateTime(2016, 4, 6, 17, 30, 0));

        Equal(Create, action.Type);
        Equal("Audit_2.txt", action.FileName);
        Equal(new[]
        {
            "1;Tom Tomson;2016-04-06T17:30:00"
        }, action.Content);
    }

    [Fact]
    public void RemoveMentionsAbout_removes_mentions_from_files_in_the_directory()
    {
        var file = new FileContent("Audit_1.txt", new[]
        {
            "1;Peter Peterson;2016-04-06T16:30:00",
            "2;Jane Doe;2016-04-06T16:40:00",
            "3;Jack Rich;2016-04-06T17:00:00"
        });

        var actions = new[] {file}.RemoveMentionsAbout( "Peter Peterson");
        

        actions.Count.ShouldBe(1);
        Equal("Audit_1.txt", actions[0].FileName);
        Equal(Update, actions[0].Type);
        Equal(new[]
        {
            "1;Jane Doe;2016-04-06T16:40:00",
            "2;Jack Rich;2016-04-06T17:00:00"
        }, actions[0].Content);
    }

    [Fact]
    public void RemoveMentionsAbout_removes_whole_file_if_it_doesnt_contain_anything_else()
    {
        var file = new FileContent("Audit_1.txt", new[]
        {
            "1;Peter Peterson;2016-04-06T16:30:00"
        });

        var actions = new[] {file}.RemoveMentionsAbout( "Peter Peterson");
        actions.Count.ShouldBe(1);
        Equal("Audit_1.txt", actions[0].FileName);
        if (actions != null) Equal(Delete, actions[0].Type);
    }

    [Fact]
    public void RemoveMentionsAbout_does_not_do_anything_in_case_no_mentions_found()
    {
        var file = new FileContent("Audit_1.txt", new[]
        {
            "1;Jane Smith;2016-04-06T16:30:00"
        });

        var actions = new[] {file}.RemoveMentionsAbout( "Peter Peterson");
        actions.Count.ShouldBe(1);
    }
}