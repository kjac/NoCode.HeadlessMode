using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Actions;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Kjac.NoCode.HeadlessMode.Handlers;

internal sealed class MenuRenderingNotificationHandler : INotificationHandler<MenuRenderingNotification>
{
    public void Handle(MenuRenderingNotification notification)
    {
        if (notification.TreeAlias is not Constants.Trees.Content)
        {
            return;
        }

        notification.Menu.Items.RemoveAll(item => item.Alias is ActionAssignDomain.ActionAlias);
    }
}
