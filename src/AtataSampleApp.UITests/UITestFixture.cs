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
            AtataContext.Configure().Build();
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
