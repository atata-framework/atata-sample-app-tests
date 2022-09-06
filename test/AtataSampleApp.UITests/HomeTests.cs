using Atata;
using NUnit.Framework;

namespace AtataSampleApp.UITests
{
    public class HomeTests : UITestFixture
    {
        [Test]
        public void Home() =>
            Go.To<HomePage>()
                .PageUrl.Should.Be(Config.BaseUrl);

        [Test]
        public void SignInAndSignUpLinks() =>
            Go.To<HomePage>()
                .SignIn.Content.Should.Be("Sign In")
                .SignUp.Content.Should.Be("Sign Up")
                .SignIn.ClickAndGo()
                    .GoBack<HomePage>()
                .SignUp.ClickAndGo();

        [Test]
        public void SignInAndSignUpLinks_Visibility() =>
            Go.To<HomePage>()
                .SignIn.Should.BeVisibleInViewPort()
                .SignUp.Should.BeVisibleInViewPort()
                .SignIn.ClickAndGo()
                    .Email.Set(Config.Account.Email)
                    .Password.Set(Config.Account.Password)
                    .SignIn()
                        .Menu.Home()
                .SignIn.Should.Not.BeVisible()
                .SignUp.Should.Not.BeVisible()
                .Menu.Account.SignOut()
                    .Menu.Home()
                .SignIn.Should.BeVisible()
                .SignUp.Should.BeVisible();
    }
}
