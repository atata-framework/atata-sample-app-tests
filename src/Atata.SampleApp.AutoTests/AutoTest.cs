using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Atata.SampleApp.AutoTests
{
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
                UseNUnitTestContextLogging().
                    WithMinLevel(LogLevel.Info).
                    WithoutSectionFinish().
                UseNLogLogging().
                UseScreenshotFileSaving(() => $@"Logs\{AtataContext.BuildStart:yyyy-MM-dd HH_mm_ss}\{AtataContext.Current.TestName}").
                SetUp();

            OnSetUp();
        }

        protected virtual void OnSetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current.Log.Screenshot();

            var testResult = TestContext.CurrentContext.Result;

            if (testResult.Outcome.Status == TestStatus.Failed)
                AtataContext.Current.Log.Error(testResult.Message, testResult.StackTrace);

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
