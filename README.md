# No-Code Headless Mode

The No-Code Headless Mode package removes unused editor features from [Umbraco CMS](https://umbraco.com/) when its used purely as a headless CMS.

> [!TIP]
> If you are extending Umbraco with custom .NET code, this package might not be for you :smile:

## Installing the package

> [!IMPORTANT]
> First and foremost, make sure the Delivery API is enabled. See the [Umbraco Delivery API docs](https://docs.umbraco.com/umbraco-cms/reference/content-delivery-api) for details.

The package is installed from [NuGet](https://www.nuget.org/packages/Kjac.NoCode.HeadlessMode):

```bash
dotnet add package Kjac.NoCode.HeadlessMode
```

The package requires no additional configuration once installed.

## An opinionated package?

This is without doubt an opinionated package. What is an "unused feature", after all? 

## So what exactly does it to?

The package focuses on removing or altering editor UI features that are either not applicable or misleading in a headless setup.

### In the content editor

- Default links to published content are removed (custom outbound links will be retained).
- The template selector is removed.
- The "Culture and Hostnames" option is removed from the content tree menu.
- Editor warnings for missing domain mappings in a multi-lingual setup are disabled.
- The "Save and Preview" button is removed, unless custom preview URLs are configured for external hosts.
- Redirect URLs are transformed to be "information only" (no outbound links).

Removing the "Culture and Hostnames" option might be controversial. However, the Delivery API provides alternative means for handling context and localization - see [Delivery API concepts](https://docs.umbraco.com/umbraco-cms/reference/content-delivery-api#concepts) for more info.

### In the Settings section

- Everything related to Razor rendering/templating is removed.
- The "Models Builder" and "Profiling" dashboards are removed (read more about these dashboards [here](https://docs.umbraco.com/umbraco-cms/fundamentals/backoffice/settings-dashboards)).

### Other things

- The "Translation" section is removed, because the Delivery API does not support translations.

## No-Code Delivery API

This package works really well with the [No-Code Delivery API](https://github.com/kjac/NoCode.DeliveryApi) package :smile:
