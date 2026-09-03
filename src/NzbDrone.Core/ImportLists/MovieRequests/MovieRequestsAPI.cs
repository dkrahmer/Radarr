using Newtonsoft.Json;

namespace NzbDrone.Core.ImportLists.MovieRequests
{
    public class MovieRequestsMovie
    {
        public int Id { get; set; }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("tmdb_id")]
        public string TmdbId { get; set; }

        public string Title { get; set; }

        public string Year { get; set; }
    }
}
