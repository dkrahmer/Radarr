using System;
using NLog;
using NzbDrone.Common.Http;
using NzbDrone.Core.Configuration;
using NzbDrone.Core.Parser;

namespace NzbDrone.Core.ImportLists.MovieRequests
{
    public class MovieRequestsImport : HttpImportListBase<MovieRequestsSettings>
    {
        public override string Name => "Movie Requests";

        public override ImportListType ListType => ImportListType.Program;
        public override TimeSpan MinRefreshInterval => TimeSpan.FromMinutes(15);
        public override bool Enabled => true;
        public override bool EnableAuto => false;

        public MovieRequestsImport(IHttpClient httpClient,
                                   IImportListStatusService importListStatusService,
                                   IConfigService configService,
                                   IParsingService parsingService,
                                   Logger logger)
            : base(httpClient, importListStatusService, configService, parsingService, logger)
        {
        }

        public override IImportListRequestGenerator GetRequestGenerator()
        {
            return new MovieRequestsRequestGenerator { Settings = Settings };
        }

        public override IParseImportListResponse GetParser()
        {
            return new MovieRequestsParser();
        }
    }
}
