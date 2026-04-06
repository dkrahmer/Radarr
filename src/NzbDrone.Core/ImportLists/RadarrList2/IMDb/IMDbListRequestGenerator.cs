using NzbDrone.Common.Http;
using Newtonsoft.Json;
using System.Net.Http;

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
                // "Browserless" IMDB proxy server: docker run -it --rm --name browserless -p 9095:3000 --shm-size="2gb" -e "DEBUG=browserless:*,puppeteer:*" -e "TIMEOUT=300000" -e "CONCURRENT=2" -e "STEALTH=true" -e "PREBOOT=true" ghcr.io/browserless/chromium:latest
                var request = new HttpRequest("http://localhost:9095/function", new HttpAccept("*/*"))
                {
                    Method = HttpMethod.Post
                };

                request.Headers.ContentType = "application/json";

                var code = $@"export default async ({{ page }}) => {{ await page.setUserAgent(""Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36""); await page.goto(""https://www.imdb.com/{imdbPath}/?sort=date_added%2Cdesc"", {{ waitUntil: ""domcontentloaded"" }}); await new Promise(r => setTimeout(r, 15000)); return await page.content(); }};";
                request.SetContent(JsonConvert.SerializeObject(new { code }));

                return request;
            }

            // This is a preset list provided by Radarr cloud
            return RequestBuilder.Create()
                .SetSegment("route", $"list/imdb/{Settings.ListId}")
                .Accept(HttpAccept.Json)
                .Build();
        }
    }
}
