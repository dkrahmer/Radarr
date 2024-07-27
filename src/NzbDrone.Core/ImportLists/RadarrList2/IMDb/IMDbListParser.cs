using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NzbDrone.Common.Extensions;
using NzbDrone.Core.ImportLists.ImportListMovies;
using NzbDrone.Core.MetadataSource.SkyHook.Resource;

namespace NzbDrone.Core.ImportLists.RadarrList2.IMDbList
{
    public class IMDbListParser : RadarrList2Parser
    {
        private readonly IMDbListSettings _settings;

        public IMDbListParser(IMDbListSettings settings)
            : base()
        {
            _settings = settings;
        }

        public override IList<ImportListMovie> ParseResponse(ImportListResponse importListResponse)
        {
            var importListMovies = new List<ImportListMovie>();

            if (!PreProcess(importListResponse))
            {
                return importListMovies;
            }

            if (importListResponse.HttpRequest.Url.Host.Contains("api.radarr.video"))
            {
                // Handle the preset list provided by Radarr cloud
                var jsonResponse = JsonConvert.DeserializeObject<List<MovieResource>>(importListResponse.Content);

                if (jsonResponse == null)
                {
                    return importListMovies;
                }

                return jsonResponse.SelectList(m => new ImportListMovie { TmdbId = m.TmdbId });
            }


            var isUserList = importListResponse.HttpRequest.Url.Path.StartsWith("/user/");

            var html = importListResponse.Content;
            var i = html.IndexOf("<script id=\"__NEXT_DATA__\" type=\"application/json\">");
            var k = html.IndexOf(">", i);
            var j = html.IndexOf("</script", k);
            var jx = html.Substring(k + 1, j - k - 1);

            var jxr = jx.Replace("/", "~").Replace("\\x", "#x#"); // Adjust any JSON escape chars
            var jsdata = JObject.Parse(jxr);

            var listName = isUserList ? "predefinedList" : "list"; // different node user list
            var listItemEdges = jsdata.SelectToken($"props.pageProps.mainColumnData.{listName}.titleListItemSearch.edges") as JArray;

            if (listItemEdges == null)
            {
                return importListMovies; // could not find edges
            }

            foreach (var listItemEdge in listItemEdges)
            {
                var listItem = listItemEdge.SelectToken("listItem");

                var type = listItem.SelectToken("titleType.id")?.ToString();
                if (!(type?.ToLower().Contains("movie") ?? false))
                    continue;  // only allow movies - "movie", "tvMovie"

                var imdbId = listItem.SelectToken("id")?.ToString();
                if (string.IsNullOrWhiteSpace(imdbId))
                    continue;

                var importListMovie = new ImportListMovie
                {
                    ImdbId = imdbId
                };

                importListMovies.Add(importListMovie);
            }

            return importListMovies;
        }
    }
}
