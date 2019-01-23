using Atata;
using NUnit.Framework;

namespace AtataSampleApp.UITests
{
    [TestFixture]
    public class UITestFixture
    {
        public AtataConfig Config
        {
            get { return AtataConfig.Current; }
        }

        [SetUp]
        public void SetUp()
        {
            AtataContext.Configure().
                ApplyJsonConfig<AtataConfig>().
                UseChrome().
                    WithLocalDriverPath().
                    WithArguments("start-maximized", "disable-infobars", "disable-extensions").
                // Base URL can be set here, but in this sample it is defined in Atata.json config file.
                //UseBaseUrl("https://atata-framework.github.io/atata-sample-app/#!/").
                UseCulture("en-US").
                UseNUnitTestName().
                AddNUnitTestContextLogging().
                // Configure logging:
                //    WithMinLevel(LogLevel.Info).
                //    WithoutSectionFinish().
                AddNLogLogging(). // Actual NLog configuration is located in NLog.config file.
                                  // Logs can be found in "{repo folder}\src\AtataSampleApp.UITests\bin\Debug\Logs\"
                AddScreenshotFileSaving().
                // Below are possible ways to specify folder path to store screenshots for individual tests.
                // Both examples build the same path which is used by default.
                //    WithFolderPath(@"Logs\{build-start}\{test-name}").
                //    WithFolderPath(() => $@"Logs\{AtataContext.BuildStart:yyyy-MM-dd HH_mm_ss}\{AtataContext.Current.TestName}").
                LogNUnitError().
                TakeScreenshotOnNUnitError().
                Build();
        }

        [TearDown]
        public void TearDown()
        {
            if (AtataContext.Current != null)
                AtataContext.Current.CleanUp();
        }

        protected UsersPage Login()
        {
            return Go.To<SignInPage>().
                Email.Set(Config.Account.Email).
                Password.Set(Config.Account.Password).
                SignIn();
        }
    }
}
