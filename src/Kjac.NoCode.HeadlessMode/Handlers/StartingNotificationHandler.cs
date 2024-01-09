using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Features;
using Umbraco.Cms.Core.Notifications;

namespace Kjac.NoCode.HeadlessMode.Handlers;

internal sealed class StartingNotificationHandler : INotificationHandler<UmbracoApplicationStartingNotification>
{
    private readonly UmbracoFeatures _umbracoFeatures;

    public StartingNotificationHandler(UmbracoFeatures umbracoFeatures)
        => _umbracoFeatures = umbracoFeatures;

    public void Handle(UmbracoApplicationStartingNotification notification)
        => _umbracoFeatures.Disabled.DisableTemplates = true;
}
