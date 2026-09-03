using System.Linq;
using System.Net;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using NzbDrone.Common.Http;
using NzbDrone.Core.ImportLists;
using NzbDrone.Core.ImportLists.Exceptions;
using NzbDrone.Core.ImportLists.MovieRequests;
using NzbDrone.Core.Test.Framework;

namespace NzbDrone.Core.Test.ImportList.MovieRequests
{
    public class MovieRequestsParserFixture : CoreTest<MovieRequestsParser>
    {
        private ImportListResponse CreateResponse(string url, string content, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var httpRequest = new HttpRequest(url);
            var httpResponse = new HttpResponse(httpRequest, new HttpHeader(), Encoding.UTF8.GetBytes(content), statusCode);

            return new ImportListResponse(new ImportListRequest(httpRequest), httpResponse);
        }

        [Test]
        public void should_parse_json_of_movie_requests()
        {
            var json = ReadAllText("Files/movie_requests.json");

            var result = Subject.ParseResponse(CreateResponse("https://requests.example.com/requests?concise=true", json));

            result.Should().HaveCount(2);
            result.First().Title.Should().Be("Inception");
            result.First().ImdbId.Should().Be("tt1375666");
            result.First().TmdbId.Should().Be(27205);
            result.First().Year.Should().Be(2010);
        }

        [Test]
        public void should_return_empty_when_no_movies()
        {
            var result = Subject.ParseResponse(CreateResponse("https://requests.example.com/requests?concise=true", "[]"));

            result.Should().BeEmpty();
        }

        [Test]
        public void should_throw_on_unexpected_status_code()
        {
            Assert.Throws<ImportListException>(() =>
                Subject.ParseResponse(CreateResponse("https://requests.example.com/requests?concise=true", "[]", HttpStatusCode.Unauthorized)));
        }
    }
}
