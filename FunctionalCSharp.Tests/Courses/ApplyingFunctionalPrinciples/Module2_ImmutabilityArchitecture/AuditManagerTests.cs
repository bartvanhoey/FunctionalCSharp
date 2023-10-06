using FluentAssertions;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Models;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Models.ActionType;

namespace FunctionalCSharp.Tests.Courses.ApplyingFunctionalPrinciples.Module2_ImmutabilityArchitecture
{
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

            action.ActionType.Should().Be(Update);
            action.FileName.Should().Be(file.FileName);
            action.Lines.Should()
                .BeEquivalentTo("1;Peter Peterson;2016-04-06T16:30:00", "2;Jane Doe;2016-04-06T17:00:00");
        }

        [Fact]
        public void AddRecord_adds_a_record_to_a_new_file_if_overflowed()
        {
            var manager = new AuditManager(3);

            var file = new FileContent("Audit_1.txt", new[]
            {
                "1;Peter Peterson;2016-04-06T16:30:00",
                "2;Jane Doe;2016-04-06T17:00:00",
                "3;Jack Rich;2016-04-06T17:40:00",
            });

            var action = manager.AddRecord(file, "Tom Tomson", new DateTime(2016, 4, 6, 17, 30, 0));

            action.ActionType.Should().Be(Create);
            action.FileName.Should().Be("Audit_2.txt");
            action.Lines.Should().BeEquivalentTo("1;Peter Peterson;2016-04-06T16:30:00",
                "2;Jane Doe;2016-04-06T17:00:00",
                "3;Jack Rich;2016-04-06T17:40:00",
                "4;Tom Tomson;2016-04-06T17:30:00");
        }

        [Fact]
        public void RemoveMentionsAbout_removes_whole_file_if_not_contains_entries()
        {
            var manager = new AuditManager(10);

            var file = new FileContent("Audit_1.txt", new[]
            {
                "1;Peter Peterson;2016-04-06T16:30:00"
            });


            var actions = manager.RemoveMentionsAbout("Peter Peterson", new[] {file});

            actions.Count.Should().Be(1);
            actions.FirstOrDefault().ActionType.Should().Be(Delete);
            actions.FirstOrDefault().FileName.Should().Be("Audit_1.txt");
            actions.FirstOrDefault().Lines.Length.Should().Be(0);
        }

        [Fact]
        public void RemoveMentionsAbout_remove_mentions_from_file_in_the_directory()
        {
            var manager = new AuditManager(10);

            var file = new FileContent("Audit_1.txt", new[]
            {
                "1;Peter Peterson;2016-04-06T16:30:00",
                "2;Jane Doe;2016-04-06T17:00:00",
                "3;Jack Rich;2016-04-06T17:40:00",
            });


            var actions = manager.RemoveMentionsAbout("Peter Peterson", new[] {file});

            actions.Count.Should().Be(1);
            actions.FirstOrDefault().FileName.Should().Be("Audit_1.txt");
            actions.FirstOrDefault().ActionType.Should().Be(Update);
            actions.FirstOrDefault().Lines
                .Should().BeEquivalentTo("1;Jane Doe;2016-04-06T17:00:00", "2;Jack Rich;2016-04-06T17:40:00");
        }
        
        [Fact]
        public void RemoveMentionsAbout_should_do_nothing_in_case_no_mentions_found()
        {
            var manager = new AuditManager(10);

            var file = new FileContent("Audit_1.txt", new[]
            {
                "2;Jane Doe;2016-04-06T17:00:00",
            });


            var actions = manager.RemoveMentionsAbout("Peter Peterson", new[] {file});

            actions.Count.Should().Be(0);
            // actions.FirstOrDefault().FileName.Should().Be("Audit_1.txt");
            // actions.FirstOrDefault().Action.Should().Be(Update);
            // actions.FirstOrDefault().Lines
            //     .Should().BeEquivalentTo("1;Jane Doe;2016-04-06T17:00:00", "2;Jack Rich;2016-04-06T17:40:00");
        }
    }
}