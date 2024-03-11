namespace FunctionalCSharp.Tests.Courses.FunctionalProgrammingWithCSharp.Module2_ExpressYourself
{



    
    public class UsingDisposableTests
    {
        // private const string JsonPlaceholderPhotos = @"https://jsonplaceholder.typicode.com/photos";

        // [Fact]
        // public async Task UsingTheOldWay_Should_Return_A_Correct_Value()
        // {
        //     var totalPages = await ConvertingStatementsToExpressions.GetTotalPages_NonFunctional();
        //     totalPages.Should().NotBeEmpty();
        // }


        // [Fact]
        // public async Task Method_UsingAsync_Should_Return_A_Correct_Value()
        // {
        //     var totalPages = await ConvertingStatementsToExpressions.GetTotalPages_Functional();
        //     totalPages.Should().NotBeEmpty();
        // }

        // [Fact]
        // [Obsolete("Obsolete")]
        // public void Method_Using_Should_Return_A_Correct_Value()
        // {
        //     
        //     string? result = null;
        //     using var client  = new WebClient();
        //     result = GetTotalPages(client);
        //
        //
        //     var totalPages = Using(
        //         () => new WebClient(),
        //         client => Parse(client.DownloadString(JsonPlaceholderPhotos)).Root?.Element("total_pages")?.Value);
        //
        //     totalPages.Should().NotBeEmpty();
        // }

        // [Fact]
        // [Obsolete("Obsolete")]
        // public void Method_Using_GetTotalPages_Should_Return_A_Correct_Value()
        // {
        //     var totalPages = Using(
        //         () => new WebClient(), 
        //         GetTotalPages);
        //     totalPages.Should().NotBeEmpty();
        // }


        // private static string? GetTotalPages(WebClient client)
        //     => Parse(client.DownloadString(JsonPlaceholderPhotos)).Root?.Element("total_pages")?.Value;
    }
}