using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Kjac.NoCode.HeadlessMode.Handlers;

internal sealed class SendingContentNotificationHandler : INotificationHandler<SendingContentNotification>
{
    public void Handle(SendingContentNotification notification)
    {
        notification.Content.Urls = notification.Content.Urls?.Where(url => url.IsUrl && url.Text.StartsWith("http")).ToArray();
        if (notification.Content.Urls?.Any() is false)
        {
            notification.Content.Urls = null;
        }
    }
}

