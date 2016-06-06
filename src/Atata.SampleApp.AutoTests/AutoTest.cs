using System.Text;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Firefox;

namespace Atata.SampleApp.AutoTests
{
    public class AutoTest
    {
        [SetUp]
        public void SetUp()
        {
            var log = new SimpleLogManager(
                message =>
                {
                    TestContext.WriteLine(message);
                });

            ATContext.SetUp(
                () => new FirefoxDriver().Maximize(),
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
                ATContext.Current.Log.Error(FormatErrorMessage(testResult.Message, testResult.StackTrace), null);

            ATContext.CleanUp();
        }

        private static string FormatErrorMessage(string message, string stackTrace)
        {
            StringBuilder builder = new StringBuilder(message);
            builder.AppendLine();

            builder.Append(stackTrace);

            return builder.ToString();
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
