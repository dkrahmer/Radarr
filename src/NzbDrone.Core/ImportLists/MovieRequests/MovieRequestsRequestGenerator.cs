using System.Collections.Generic;
using NzbDrone.Common.Extensions;
using NzbDrone.Common.Http;

namespace NzbDrone.Core.ImportLists.MovieRequests
{
    public class MovieRequestsRequestGenerator : IImportListRequestGenerator
    {
        public MovieRequestsSettings Settings { get; set; }

        public virtual ImportListPageableRequestChain GetMovies()
        {
            var pageableRequests = new ImportListPageableRequestChain();

            pageableRequests.Add(GetMoviesRequest());

            return pageableRequests;
        }

        private IEnumerable<ImportListRequest> GetMoviesRequest()
        {
            var requestBuilder = new HttpRequestBuilder(Settings.BaseUrl.Trim().TrimEnd('/'))
                .Resource("requests")
                .Accept(HttpAccept.Json)
                .SetHeader("Authorization", $"Bearer {Settings.Token}")
                .AddQueryParam("concise", "true");

            if (Settings.Category.IsNotNullOrWhiteSpace())
            {
                requestBuilder.AddQueryParam("category", Settings.Category);
            }

            yield return new ImportListRequest(requestBuilder.Build());
        }
    }
}
