using Atata;
using NUnit.Framework;

namespace AtataSampleApp.UITests
{
    [SetUpFixture]
    public class SetUpFixture
    {
        [OneTimeSetUp]
        public void GlobalSetUp() =>
            AtataContext.GlobalConfiguration
                .ApplyJsonConfig<AtataConfig>()
                .UseDefaultArtifactsPathIncludingBuildStart(
                    TestContext.Parameters.Get("UseDefaultArtifactsPathIncludingBuildStart", true))
                .AutoSetUpDriverToUse();
    }
}
