using NzbDrone.Core.Configuration;
using Radarr.Http.REST;

namespace NzbDrone.Api.Config
{
    public class DownloadClientConfigResource : RestResource
    {
        public string DownloadedMoviesFolder { get; set; }
        public int DownloadedMoviesScanInterval { get; set; }
        public string DownloadClientWorkingFolders { get; set; }

        public bool EnableCompletedDownloadHandling { get; set; }
        public bool RemoveCompletedDownloads { get; set; }
        public int CheckForFinishedDownloadInterval { get; set; }

        public bool AutoRedownloadFailed { get; set; }
        public bool RemoveFailedDownloads { get; set; }
    }

    public static class DownloadClientConfigResourceMapper
    {
        public static DownloadClientConfigResource ToResource(IConfigService model)
        {
            return new DownloadClientConfigResource
            {
                DownloadedMoviesFolder = model.DownloadedMoviesFolder,
                DownloadedMoviesScanInterval = model.DownloadedMoviesScanInterval,
                DownloadClientWorkingFolders = model.DownloadClientWorkingFolders,

                EnableCompletedDownloadHandling = model.EnableCompletedDownloadHandling,
                RemoveCompletedDownloads = model.RemoveCompletedDownloads,
                CheckForFinishedDownloadInterval = model.CheckForFinishedDownloadInterval,

                AutoRedownloadFailed = model.AutoRedownloadFailed,
                RemoveFailedDownloads = model.RemoveFailedDownloads
            };
        }
    }
}
