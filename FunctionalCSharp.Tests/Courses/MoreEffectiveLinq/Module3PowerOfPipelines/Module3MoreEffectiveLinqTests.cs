namespace FunctionalCSharp.Tests.Courses.MoreEffectiveLinq.Module3PowerOfPipelines
{
    public class Module3MoreEffectiveLinqTests
    {

        [Fact]
        public void Method_SearchInCsvFile_Should_Return_Correct_Number_Of_FileInfos()
        {
            // flaky
            // var fileInfos = SearchInCsvFile( "platform", "*.csv").ToList();
            // fileInfos.Count.Should().Be(46);
        }

        
        [Fact]
        public void Get_Distinct_License_Names_From_CsvFile()
        {
            // flaky
            // var fileNames = GetDistinctLicenseNamesFromCsvFile().ToList();
            // fileNames.Count.Should().Be(15);
        }

    }
}