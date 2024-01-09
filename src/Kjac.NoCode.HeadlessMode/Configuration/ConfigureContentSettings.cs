using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Configuration.Models;

namespace Kjac.NoCode.HeadlessMode.Configuration;

internal sealed class ConfigureContentSettings : IConfigureNamedOptions<ContentSettings>
{
    public void Configure(string? name, ContentSettings options)
        => Configure(options);

    public void Configure(ContentSettings options)
        => options.ShowDomainWarnings = false;
}
