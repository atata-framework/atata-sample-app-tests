using Atata;
using NUnit.Framework;

namespace AtataSampleApp.AutoTests
{
    [TestFixture]
    public class UITestFixture
    {
        [SetUp]
        public void SetUp()
        {
            AtataContext.Configure().
                UseChrome().
                    WithArguments("disable-extensions", "start-maximized", "disable-infobars").
                UseBaseUrl(Config.Url).
                UseNUnitTestName().
                AddNUnitTestContextLogging().
                    WithMinLevel(LogLevel.Info).
                    WithoutSectionFinish().
                AddNLogLogging().
                AddScreenshotFileSaving().
                // Below are possible ways to specify folder path to store screenshots for individual tests.
                // Both examples build the same path which is used by default.
                //WithFolderPath(@"Logs\{build-start}\{test-name}").
                //WithFolderPath(() => $@"Logs\{AtataContext.BuildStart:yyyy-MM-dd HH_mm_ss}\{AtataContext.Current.TestName}").
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
