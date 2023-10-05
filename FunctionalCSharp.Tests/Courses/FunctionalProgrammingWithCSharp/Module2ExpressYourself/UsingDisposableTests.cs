using System.Net;
using System.Xml.Linq;
using FluentAssertions;
using static System.Xml.Linq.XDocument;
using static FunctionalCSharp.Extensions.UsingExtended;

namespace FunctionalCSharp.Tests.Courses.FunctionalProgrammingWithCSharp.Module2ExpressYourself
{
    public class UsingDisposableTests
    {
        private const string TravelApiUrl = @"http://restapi.adequateshop.com/api/Traveler";

        [Fact]
        public async Task UsingTheOldWay_Should_Return_A_Correct_Value()
        {
            XDocument xDocument;
            using (var client = new HttpClient())
            {
                xDocument = Parse(await client.GetStringAsync(TravelApiUrl));
            }

            var totalPages = xDocument.Root?.Element("total_pages")?.Value;
            totalPages.Should().NotBeEmpty();
        }


        [Fact]
        public async Task Method_UsingAsync_Should_Return_A_Correct_Value()
        {
            var totalPages = (await await UsingAsync(
                    () => new HttpClient(),
                    async client => Parse(await client.GetStringAsync(TravelApiUrl))))
                .Root?.Element("total_pages")?.Value;

            totalPages.Should().NotBeEmpty();
        }

        [Fact]
        [Obsolete("Obsolete")]
        public void Method_Using_Should_Return_A_Correct_Value()
        {
            
            string? result = null;
            using var client  = new WebClient();
            result = GetTotalPages(client);


            var totalPages = Using(
                () => new WebClient(),
                client => Parse(client.DownloadString(TravelApiUrl)).Root?.Element("total_pages")?.Value);

            totalPages.Should().NotBeEmpty();
        }

        [Fact]
        [Obsolete("Obsolete")]
        public void Method_Using_GetTotalPages_Should_Return_A_Correct_Value()
        {
            var totalPages = Using(
                () => new WebClient(), 
                GetTotalPages);
            totalPages.Should().NotBeEmpty();
        }


        private static string? GetTotalPages(WebClient client)
            => Parse(client.DownloadString(TravelApiUrl)).Root?.Element("total_pages")?.Value;
    }
}