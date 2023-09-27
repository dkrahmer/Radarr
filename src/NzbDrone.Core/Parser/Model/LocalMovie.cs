using System;
using System.Collections.Generic;
using System.Linq;
using NzbDrone.Core.CustomFormats;
using NzbDrone.Core.Download;
using NzbDrone.Core.Languages;
using NzbDrone.Core.MediaFiles;
using NzbDrone.Core.MediaFiles.MediaInfo;
using NzbDrone.Core.Movies;
using NzbDrone.Core.Qualities;

namespace NzbDrone.Core.Parser.Model
{
    public class LocalMovie
    {
        public static readonly string[] ImmutableSubdirectories = new string[] { "VIDEO_TS" };

        public LocalMovie()
        {
            CustomFormats = new List<CustomFormat>();
        }

        private string _path;
        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                SubdirectoryName = null;
                _path = value;
            }
        }

        private bool? _isImmutableSubdirectory;
        public bool IsImmutableSubdirectory
        {
            get
            {
                if (!_isImmutableSubdirectory.HasValue)
                {
                    if (string.IsNullOrEmpty(SubdirectoryName))
                    {
                        _isImmutableSubdirectory = false;
                    }
                    else
                    {
                        _isImmutableSubdirectory = ImmutableSubdirectories.Contains(SubdirectoryName, StringComparer.OrdinalIgnoreCase);
                    }
                }

                return _isImmutableSubdirectory.Value;
            }
        }

        private string _subdirectoryName;
        public string SubdirectoryName
        {
            get
            {
                if (_subdirectoryName == null)
                {
                    if (string.IsNullOrEmpty(_path))
                    {
                        SubdirectoryName = _path;
                    }
                    else
                    {
                        _subdirectoryName = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(_path));
                    }
                }

                return _subdirectoryName;
            }
            private set
            {
                _isImmutableSubdirectory = null;
                _subdirectoryName = value;
            }
        }

        public long Size { get; set; }
        public ParsedMovieInfo FileMovieInfo { get; set; }
        public ParsedMovieInfo DownloadClientMovieInfo { get; set; }
        public DownloadClientItem DownloadItem { get; set; }
        public ParsedMovieInfo FolderMovieInfo { get; set; }
        public Movie Movie { get; set; }
        public List<MovieFile> OldFiles { get; set; }
        public QualityModel Quality { get; set; }
        public List<Language> Languages { get; set; }
        public MediaInfoModel MediaInfo { get; set; }
        public bool ExistingFile { get; set; }
        public bool SceneSource { get; set; }
        public string ReleaseGroup { get; set; }
        public string Edition { get; set; }
        public string SceneName { get; set; }
        public bool OtherVideoFiles { get; set; }
        public List<CustomFormat> CustomFormats { get; set; }
        public int CustomFormatScore { get; set; }
        public GrabbedReleaseInfo Release { get; set; }

        public override string ToString()
        {
            return Path;
        }
    }
}
