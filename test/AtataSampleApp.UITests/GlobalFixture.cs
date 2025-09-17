﻿using Microsoft.Extensions.Configuration;
using NUnit.Framework.Internal;

[assembly: SetCulture("en-US")]
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace AtataSampleApp.UITests;

[SetUpFixture]
public sealed class GlobalFixture : AtataGlobalFixture
{
    private GlobalConfig? _config;

    protected override void ConfigureAtataContextGlobalProperties(AtataContextGlobalProperties globalProperties)
    {
        LoadConfiguration();

        AtataContext.GlobalProperties.UseDefaultArtifactsRootPathTemplateExcludingRunStartOnCI();
    }

    protected override void ConfigureAtataContextBaseConfiguration(AtataContextBuilder builder)
    {
        builder.LogConsumers.AddNLogFile();

        builder.Sessions.AddWebDriver(x => x
            .UseStartScopes(AtataContextScopes.Test)
            .UseChrome(x => x
                .WithArguments(
                    "disable-search-engine-choice-screen",
                    "window-size=1200,800",
                    "headless=new"))
            .UseBaseUrl(_config!.BaseUrl));

        builder.Attributes.Global.Add(new VerifyTitleSettingsAttribute { Format = "{0} - Atata Sample App" });
    }

    protected override void ConfigureGlobalAtataContext(AtataContextBuilder builder)
    {
        builder.UseState(_config);

        builder.EventSubscriptions.Add(SetUpWebDriversForUseEventHandler.Instance);
    }

    private void LoadConfiguration()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddInMemoryCollection(TestContext.Parameters.Names.Select(x => KeyValuePair.Create(x, TestContext.Parameters.Get(x))))
            .Build();

        _config = configuration.Get<GlobalConfig>();
    }
}
