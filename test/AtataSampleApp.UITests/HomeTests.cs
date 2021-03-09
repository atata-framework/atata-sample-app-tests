using Atata;
using NUnit.Framework;

namespace AtataSampleApp.UITests
{
    public class HomeTests : UITestFixture
    {
        [Test]
        public void Home()
        {
            Go.To<HomePage>()
                .PageUrl.Should.Equal(Config.BaseUrl);
        }

        [Test]
        public void SignInAndSignUpLinks()
        {
            Go.To<HomePage>()
                .SignIn.Content.Should.Equal("Sign In")
                .SignUp.Content.Should.Equal("Sign Up")
                .SignIn.ClickAndGo()
                    .GoBack<HomePage>()
                .SignUp.ClickAndGo();
        }

        [Test]
        public void SignInAndSignUpLinks_Visibility()
        {
            Go.To<HomePage>()
                .SignIn.Should.BeVisibleInViewPort()
                .SignUp.Should.BeVisibleInViewPort()
                .SignIn.ClickAndGo()
                    .Email.Set(Config.Account.Email)
                    .Password.Set(Config.Account.Password)
                    .SignIn()
                        .Menu.Home()
                .SignIn.Should.Not.Exist()
                .SignUp.Should.Not.Exist()
                .Menu.Account.SignOut()
                    .Menu.Home()
                .SignIn.Should.Exist()
                .SignUp.Should.Exist();
        }
    }
}
