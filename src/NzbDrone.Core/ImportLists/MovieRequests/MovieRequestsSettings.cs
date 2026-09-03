using FluentValidation;
using NzbDrone.Core.Annotations;
using NzbDrone.Core.ThingiProvider;
using NzbDrone.Core.Validation;

namespace NzbDrone.Core.ImportLists.MovieRequests
{
    public class MovieRequestsSettingsValidator : AbstractValidator<MovieRequestsSettings>
    {
        public MovieRequestsSettingsValidator()
        {
            RuleFor(c => c.BaseUrl).ValidRootUrl();
            RuleFor(c => c.Token).NotEmpty();
        }
    }

    public class MovieRequestsSettings : IProviderConfig
    {
        private static readonly MovieRequestsSettingsValidator Validator = new MovieRequestsSettingsValidator();

        public MovieRequestsSettings()
        {
            BaseUrl = "";
            Token = "";
            Category = "";
        }

        [FieldDefinition(0, Label = "Base API URL", Type = FieldType.Url, HelpText = "Base URL of the Movie Requests API, including http(s):// and any URL base")]
        public string BaseUrl { get; set; }

        [FieldDefinition(1, Label = "Token", Type = FieldType.Password, Privacy = PrivacyLevel.ApiKey, HelpText = "Bearer token used to authenticate with the Movie Requests API")]
        public string Token { get; set; }

        [FieldDefinition(2, Label = "Category", HelpText = "Optional category to filter requests. Leave blank to include all categories.")]
        public string Category { get; set; }

        public NzbDroneValidationResult Validate()
        {
            return new NzbDroneValidationResult(Validator.Validate(this));
        }
    }
}
