using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using NzbDrone.Common.Http;
using NzbDrone.Core.ImportLists;
using NzbDrone.Core.ImportLists.MovieRequests;
using NzbDrone.Core.Test.Framework;

namespace NzbDrone.Core.Test.ImportList.MovieRequests
{
    [TestFixture]
    public class MovieRequestsFixture : CoreTest<MovieRequestsImport>
    {
        [SetUp]
        public void Setup()
        {
            Subject.Definition = new ImportListDefinition
            {
                Name = "Movie Requests",
                Settings = new MovieRequestsSettings
                {
                    BaseUrl = "https://requests.example.com",
                    Token = "secret-token",
                    Category = "wanted"
                }
            };
        }

        private void GivenResponse(string jsonFile)
        {
            var content = ReadAllText(@"Files/" + jsonFile);

            Mocker.GetMock<IHttpClient>()
                .Setup(o => o.Execute(It.IsAny<HttpRequest>()))
                .Returns<HttpRequest>(r => new HttpResponse(r, new HttpHeader(), content));
        }

        [Test]
        public void should_fetch_movie_requests()
        {
            GivenResponse("movie_requests.json");

            var result = Subject.Fetch();

            result.AnyFailure.Should().BeFalse();
            result.Movies.Should().HaveCount(2);
            result.Movies.First().Title.Should().Be("Inception");
            result.Movies.First().ImdbId.Should().Be("tt1375666");
            result.Movies.First().TmdbId.Should().Be(27205);
            result.Movies.First().Year.Should().Be(2010);
        }
    }
}
