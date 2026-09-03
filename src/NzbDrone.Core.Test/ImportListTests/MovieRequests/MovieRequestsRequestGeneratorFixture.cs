using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using NzbDrone.Core.ImportLists.MovieRequests;
using NzbDrone.Core.Test.Framework;

namespace NzbDrone.Core.Test.ImportList.MovieRequests
{
    public class MovieRequestsRequestGeneratorFixture : CoreTest<MovieRequestsRequestGenerator>
    {
        [SetUp]
        public void Setup()
        {
            Subject.Settings = new MovieRequestsSettings
            {
                BaseUrl = "https://requests.example.com/api/",
                Token = "secret-token",
                Category = "wanted"
            };
        }

        [Test]
        public void should_request_requests_with_auth_header_and_category()
        {
            var results = Subject.GetMovies();

            results.GetAllTiers().Should().HaveCount(1);

            var page = results.GetAllTiers().First().First();

            page.Url.FullUri.Should().Be("https://requests.example.com/api/requests?concise=true&category=wanted");
            page.HttpRequest.Headers.Get("Authorization").Should().Be("Bearer secret-token");
        }

        [Test]
        public void should_omit_category_when_not_set()
        {
            Subject.Settings.Category = "";

            var page = Subject.GetMovies().GetAllTiers().First().First();

            page.Url.FullUri.Should().Be("https://requests.example.com/api/requests?concise=true");
            page.Url.Query.Should().NotContain("category");
        }
    }
}
