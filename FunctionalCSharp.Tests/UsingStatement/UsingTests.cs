using System.Net;
using System.Xml.Linq;
using FluentAssertions;
using static System.Xml.Linq.XDocument;
using static FunctionalCSharp.Functional.UsingStatement.Disposable;

namespace FunctionalCSharp.Tests.UsingStatement
{
    public class UsingTests
    {
        [Fact]
        public async Task UsingTheOldWay_Should_Return_A_Correct_Value()
        {
            const string travelApiUrl = @"http://restapi.adequateshop.com/api/Traveler";

            XDocument xDocument;
            using (var client = new HttpClient())
            {
                xDocument = Parse( await (client.GetStringAsync(travelApiUrl)));
            }

            var totalPages = xDocument.Root?.Element("total_pages")?.Value;
            totalPages.Should().NotBeEmpty();
        }
        
        
        [Fact]
        public async Task Method_UsingAsync_Should_Return_A_Correct_Value()
        {
            const string travelApiUrl = @"http://restapi.adequateshop.com/api/Traveler";

            var totalPages = (await await UsingAsync(
                    () => new HttpClient(),
                    async client => Parse(await client.GetStringAsync(travelApiUrl))))
                .Root?.Element("total_pages")?.Value;

            totalPages.Should().NotBeEmpty();
        }
        
        [Fact]
        public void Method_Using_Should_Return_A_Correct_Value()
        {
            const string travelApiUrl = @"http://restapi.adequateshop.com/api/Traveler";

            var totalPages = Using(
                () => new WebClient(),
                client => Parse(client.DownloadString(travelApiUrl)))
                    .Root?.Element("total_pages")?.Value;

            totalPages.Should().NotBeEmpty();
        }
    }
}