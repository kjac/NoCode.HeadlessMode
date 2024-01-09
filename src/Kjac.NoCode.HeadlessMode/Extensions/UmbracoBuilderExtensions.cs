using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Web.BackOffice.Trees;
using Umbraco.Extensions;

namespace Kjac.NoCode.HeadlessMode.Extensions;

internal static class UmbracoBuilderExtensions
{
    public static IUmbracoBuilder RemoveTemplatingTreeGroupControllers(this IUmbracoBuilder builder)
    {
        TreeCollectionBuilder? treeCollectionBuilder = builder.Trees();
        if (treeCollectionBuilder is not null)
        {
            treeCollectionBuilder.RemoveTreeController<PartialViewMacrosTreeController>();
            treeCollectionBuilder.RemoveTreeController<PartialViewsTreeController>();
            treeCollectionBuilder.RemoveTreeController<ScriptsTreeController>();
            treeCollectionBuilder.RemoveTreeController<StylesheetsTreeController>();
            treeCollectionBuilder.RemoveTreeController<TemplatesTreeController>();
        }

        return builder;
    }
}
