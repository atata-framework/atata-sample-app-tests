using NUnit.Framework;
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

            string startUrl = Config.Url;

            ATContext.SetUp(
                () => new FirefoxDriver().Maximize(),
                log,
                TestContext.CurrentContext.Test.Name,
                startUrl);

            OnSetUp();
        }

        protected virtual void OnSetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
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
