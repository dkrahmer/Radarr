using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using NzbDrone.Common.Extensions;
using NzbDrone.Core.ImportLists.Exceptions;
using NzbDrone.Core.ImportLists.ImportListMovies;

namespace NzbDrone.Core.ImportLists.MovieRequests
{
    public class MovieRequestsParser : IParseImportListResponse
    {
        public IList<ImportListMovie> ParseResponse(ImportListResponse importResponse)
        {
            var movies = new List<ImportListMovie>();

            if (!PreProcess(importResponse))
            {
                return movies;
            }

            var jsonResponse = JsonConvert.DeserializeObject<List<MovieRequestsMovie>>(importResponse.Content);

            if (jsonResponse == null)
            {
                return movies;
            }

            foreach (var item in jsonResponse)
            {
                int.TryParse(item.TmdbId, out var tmdbId);
                int.TryParse(item.Year, out var year);

                movies.AddIfNotNull(new ImportListMovie
                {
                    Title = item.Title,
                    ImdbId = item.ImdbId,
                    TmdbId = tmdbId,
                    Year = year
                });
            }

            return movies;
        }

        protected virtual bool PreProcess(ImportListResponse importListResponse)
        {
            if (importListResponse.HttpResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new ImportListException(importListResponse, "Movie Requests API call resulted in an unexpected StatusCode [{0}]", importListResponse.HttpResponse.StatusCode);
            }

            if (importListResponse.HttpResponse.Headers.ContentType != null && importListResponse.HttpResponse.Headers.ContentType.Contains("text/json") &&
                importListResponse.HttpRequest.Headers.Accept != null && !importListResponse.HttpRequest.Headers.Accept.Contains("text/json"))
            {
                throw new ImportListException(importListResponse, "Movie Requests responded with html content. Site is likely blocked or unavailable.");
            }

            return true;
        }
    }
}
