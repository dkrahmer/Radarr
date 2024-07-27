using NzbDrone.Common.Http;

namespace NzbDrone.Core.ImportLists.RadarrList2.IMDbList
{
    public class IMDbListRequestGenerator : RadarrList2RequestGeneratorBase
    {
        public IMDbListSettings Settings { get; set; }

        protected override HttpRequest GetHttpRequest()
        {
            var imdbPath = Settings.ListId.StartsWith("ur") ?
                $"user/{Settings.ListId}/watchlist"
                : Settings.ListId.StartsWith("ls") ?
                $"list/{Settings.ListId}"
                : null;

            if (imdbPath != null)
            {
                return new HttpRequest($"https://www.imdb.com/{imdbPath}/?sort=date_added%2Cdesc", new HttpAccept("*/*"));
            }

            // This is a preset list provided by Radarr cloud
            return RequestBuilder.Create()
                .SetSegment("route", $"list/imdb/{Settings.ListId}")
                .Accept(HttpAccept.Json)
                .Build();
        }
    }
}
