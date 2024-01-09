using Kjac.NoCode.HeadlessMode.Extensions;
using Kjac.NoCode.HeadlessMode.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Dashboards;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Sections;

namespace Kjac.NoCode.HeadlessMode.Configuration;

public sealed class Composer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.RemoveTemplatingTreeGroupControllers();
        builder.Dashboards().Remove<ProfilerDashboard>();
        builder.Sections().Remove<TranslationSection>();
        builder.AddNotificationHandler<UmbracoApplicationStartingNotification, StartingNotificationHandler>();
        builder.AddNotificationHandler<SendingContentNotification, SendingContentNotificationHandler>();
        builder.AddNotificationHandler<MenuRenderingNotification, MenuRenderingNotificationHandler>();
        builder.Services.ConfigureOptions<ConfigureContentSettings>();
    }
}
