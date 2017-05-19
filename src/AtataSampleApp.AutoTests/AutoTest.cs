using NUnit.Framework;

namespace Atata.SampleApp.AutoTests
{
    [TestFixture]
    public class AutoTest
    {
        [SetUp]
        public void SetUp()
        {
            AtataContext.Build().
                UseChrome().
                    WithArguments("disable-extensions", "no-sandbox", "start-maximized").
                UseBaseUrl(Config.Url).
                UseNUnitTestName().
                AddNUnitTestContextLogging().
                    WithMinLevel(LogLevel.Info).
                    WithoutSectionFinish().
                AddNLogLogging().
                AddScreenshotFileSaving().
                    WithFolderPath(() => $@"Logs\{AtataContext.BuildStart:yyyy-MM-dd HH_mm_ss}\{AtataContext.Current.TestName}").
                LogNUnitError().
                TakeScreenshotOnNUnitError().
                SetUp();

            OnSetUp();
        }

        protected virtual void OnSetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
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
