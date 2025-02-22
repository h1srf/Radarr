using FluentValidation;
using NzbDrone.Core.Annotations;
using NzbDrone.Core.ThingiProvider;
using NzbDrone.Core.Validation;

namespace NzbDrone.Core.Notifications.Gotify
{
    public class GotifySettingsValidator : AbstractValidator<GotifySettings>
    {
        public GotifySettingsValidator()
        {
            RuleFor(c => c.Server).IsValidUrl();
            RuleFor(c => c.AppToken).NotEmpty();
        }
    }

    public class GotifySettings : IProviderConfig
    {
        private static readonly GotifySettingsValidator Validator = new GotifySettingsValidator();

        public GotifySettings()
        {
            Priority = 5;
        }

        [FieldDefinition(0, Label = "NotificationsGotifySettingsServer", HelpText = "")]
        public string Server { get; set; }

        [FieldDefinition(1, Label = "NotificationsGotifySettingsAppToken", Privacy = PrivacyLevel.ApiKey, HelpText = "NotificationsGotifySettingsAppTokenHelpText")]
        public string AppToken { get; set; }

        [FieldDefinition(2, Label = "Priority", Type = FieldType.Select, SelectOptions = typeof(GotifyPriority), HelpText = "NotificationsGotifySettingsPriorityHelpText")]
        public int Priority { get; set; }

        [FieldDefinition(3, Label = "NotificationsGotifySettingIncludeMoviePoster", Type = FieldType.Checkbox, HelpText = "NotificationsGotifySettingIncludeMoviePosterHelpText")]
        public bool IncludeMoviePoster { get; set; }

        public NzbDroneValidationResult Validate()
        {
            return new NzbDroneValidationResult(Validator.Validate(this));
        }
    }
}
