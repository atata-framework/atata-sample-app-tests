using Atata;
using NUnit.Framework;

namespace AtataSampleApp.UITests;

[SetUpFixture]
public class SetUpFixture
{
    [OneTimeSetUp]
    public void GlobalSetUp()
    {
        AtataContext.GlobalProperties.UseDefaultArtifactsRootPathTemplateIncludingBuildStart(
            TestContext.Parameters.Get("UseDefaultArtifactsPathIncludingBuildStart", true));

        AtataContext.GlobalConfiguration
            .ApplyJsonConfig<AtataConfig>()
            .AutoSetUpDriverToUse();
    }
}
