using Atata;
using NUnit.Framework;

namespace AtataSampleApp.UITests
{
    [SetUpFixture]
    public class SetUpFixture
    {
        [OneTimeSetUp]
        public void GlobalSetUp()
        {
            AtataContext.GlobalConfiguration
                .ApplyJsonConfig<AtataConfig>()
                .UseChrome()
                    .WithArguments("start-maximized")
                // Base URL can be set here, but in this sample it is defined in Atata.json config file.
                //.UseBaseUrl("https://demo.atata.io/")
                .UseCulture("en-US")
                .UseAllNUnitFeatures()
                // Configure logging:
                //    .WithMinLevel(LogLevel.Info)
                //    .WithoutSectionFinish().
                .AddNLogLogging() // Actual NLog configuration is located in NLog.config file.
                                  // Logs can be found in "{repo folder}\src\AtataSampleApp.UITests\bin\Debug\Logs\"
                .AddScreenshotFileSaving()
                // Below are the possible ways to specify the folder path to store screenshots for individual tests.
                // Both examples build the same path which is used by default.
                //    .WithFolderPath(@"Logs\{build-start}\{test-name}")
                //    .WithFolderPath(() => $@"Logs\{AtataContext.BuildStart:yyyy-MM-dd HH_mm_ss}\{AtataContext.Current.TestName}")
                .AutoSetUpDriverToUse();
        }
    }
}
