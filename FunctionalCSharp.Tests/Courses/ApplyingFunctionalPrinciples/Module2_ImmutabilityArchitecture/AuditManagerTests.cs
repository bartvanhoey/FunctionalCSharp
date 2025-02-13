using Shouldly;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Extensions;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Models;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Models.ActionType;

namespace FunctionalCSharp.Tests.Courses.ApplyingFunctionalPrinciples.Module2_ImmutabilityArchitecture;

public class AuditManagerTests
{
    [Fact]
    public void AddRecord_adds_a_record_to_an_existing_file_if_not_overflowed()
    {
        var manager = new AuditManager(10);

        var file = new FileContent("Audit_1.txt", [
            "1;Peter Peterson;2016-04-06T16:30:00"
        ]);

        var action = manager.AddRecord(file, "Jane Doe", new DateTime(2016, 4, 6, 17, 0, 0));

        action.Type.ShouldBe(Update);
        action.FileName.ShouldBe(file.FileName);
        action.Content[0].ShouldBeEquivalentTo("1;Peter Peterson;2016-04-06T16:30:00", "2;Jane Doe;2016-04-06T17:00:00");
    }

    [Fact]
    public void AddRecord_adds_a_record_to_a_new_file_if_overflowed()
    {
        var manager = new AuditManager(3);

        var file = new FileContent("Audit_1.txt", [
            "1;Peter Peterson;2016-04-06T16:30:00",
            "2;Jane Doe;2016-04-06T17:00:00",
            "3;Jack Rich;2016-04-06T17:40:00"
        ]);

        var action = manager.AddRecord(file, "Tom Tomson", new DateTime(2016, 4, 6, 17, 30, 0));

        action.Type.ShouldBe(Create);
        action.FileName.ShouldBe("Audit_2.txt");
        action.Content[0].ShouldBeEquivalentTo("1;Tom Tomson;2016-04-06T17:30:00");
    }

    [Fact]
    public void RemoveMentionsAbout_removes_whole_file_if_not_contains_entries()
    {
        var file = new FileContent("Audit_1.txt", [
            "1;Peter Peterson;2016-04-06T16:30:00"
        ]);


        var fileContents = new[] {file};
        var actions = fileContents.RemoveMentionsAbout( "Peter Peterson");

        actions.Count.ShouldBe(1);
        actions.FirstOrDefault()?.Type.ShouldBe(Delete);
        actions.FirstOrDefault()?.FileName.ShouldBe("Audit_1.txt");
        actions.FirstOrDefault()?.Content.Length.ShouldBe(0);
    }

    [Fact]
    public void RemoveMentionsAbout_remove_mentions_from_file_in_the_directory()
    {
        var file = new FileContent("Audit_1.txt", [
            "1;Peter Peterson;2016-04-06T16:30:00",
            "2;Jane Doe;2016-04-06T17:00:00",
            "3;Jack Rich;2016-04-06T17:40:00"
        ]);
        var fileContents = new[] {file};
        var actions = fileContents.RemoveMentionsAbout( "Peter Peterson");

       
        actions.Count.ShouldBe(1);
        actions.FirstOrDefault()?.FileName.ShouldBe("Audit_1.txt");
        actions.FirstOrDefault()?.Type.ShouldBe(Update);
        actions.FirstOrDefault()
            ?.Content[0]
            .ShouldBeEquivalentTo("1;Jane Doe;2016-04-06T17:00:00", "2;Jack Rich;2016-04-06T17:40:00");
    }
        
    [Fact]
    public void RemoveMentionsAbout_should_do_nothing_in_case_no_mentions_found()
    {
        var manager = new AuditManager(10);

        var file = new FileContent("Audit_1.txt", [
            "2;Jane Doe;2016-04-06T17:00:00"
        ]);

        var fileContents = new[] {file};
        var actions = fileContents.RemoveMentionsAbout( "Peter Peterson");
       

        actions.Count.ShouldBe(0);
        // actions.FirstOrDefault().FileName.ShouldBe("Audit_1.txt");
        // actions.FirstOrDefault().Action.ShouldBe(Update);
        // actions.FirstOrDefault().Lines
        //     .ShouldBeEquivalentTo("1;Jane Doe;2016-04-06T17:00:00", "2;Jack Rich;2016-04-06T17:40:00");
    }
}