using FluentValidation;
using NzbDrone.Core.Configuration;
using NzbDrone.Core.Validation.Paths;
using Radarr.Http;

namespace Radarr.Api.V3.Config
{
    [V3ApiController("config/downloadclient")]
    public class DownloadClientConfigController : ConfigController<DownloadClientConfigResource>
    {
        public DownloadClientConfigController(IConfigService configService,
                                              RootFolderValidator rootFolderValidator,
                                              PathExistsValidator pathExistsValidator,
                                              MappedNetworkDriveValidator mappedNetworkDriveValidator)
            : base(configService)
        {
            SharedValidator.RuleFor(c => c.DownloadedMoviesFolder)
                           .Cascade(CascadeMode.Stop)
                           .IsValidPath()
                           .SetValidator(rootFolderValidator)
                           .SetValidator(mappedNetworkDriveValidator)
                           .SetValidator(pathExistsValidator)
                           .When(c => !string.IsNullOrWhiteSpace(c.DownloadedMoviesFolder));
        }

        protected override DownloadClientConfigResource ToResource(IConfigService model)
        {
            return DownloadClientConfigResourceMapper.ToResource(model);
        }
    }
}
