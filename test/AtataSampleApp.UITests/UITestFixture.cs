using Atata;
using NUnit.Framework;

namespace AtataSampleApp.UITests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public abstract class UITestFixture
    {
        public static AtataConfig Config =>
            AtataConfig.Current;

        [SetUp]
        public void SetUp() =>
            AtataContext.Configure().Build();

        [TearDown]
        public void TearDown() =>
            AtataContext.Current?.CleanUp();

        protected static UsersPage Login() =>
            Go.To<SignInPage>()
                .Email.Set(Config.Account.Email)
                .Password.Set(Config.Account.Password)
                .SignIn();
    }
}
