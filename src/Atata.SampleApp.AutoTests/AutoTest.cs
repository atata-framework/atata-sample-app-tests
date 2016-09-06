using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;

namespace Atata.SampleApp.AutoTests
{
    public class AutoTest
    {
        [SetUp]
        public void SetUp()
        {
            var log = new LogManager().
                Use(new NUnitTestContextLogConsumer()).
                Use(new NLogConsumer()).
                Use(new FileScreenshotConsumer(() => $@"Logs\{ATContext.BuildStart:yyyy_MM_dd HH_mm_ss}\{ATContext.Current.TestName}"));

            ATContext.SetUp(
                () => new ChromeDriver().Maximize(),
                log,
                TestContext.CurrentContext.Test.Name,
                Config.Url);

            OnSetUp();
        }

        protected virtual void OnSetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
            var testResult = TestContext.CurrentContext.Result;
            if (testResult.Outcome.Status == TestStatus.Failed)
                ATContext.Current.Log.Error(testResult.Message, testResult.StackTrace);

            ATContext.CleanUp();
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
