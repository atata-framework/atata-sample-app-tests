using Atata;
using NUnit.Framework;

namespace AtataSampleApp.UITests
{
    public class HomeTests : UITestFixture
    {
        [Test]
        public void Home()
        {
            Go.To<HomePage>().
                PageUrl.Should.EndWith("/#!/");
        }

        [Test]
        public void Home_SignInAndSignUpLinks()
        {
            Go.To<HomePage>().
                SignIn.Content.Should.Equal("Sign In").
                SignUp.Content.Should.Equal("Sign Up").
                SignIn.ClickAndGo().
                    GoBack<HomePage>().
                SignUp.ClickAndGo();
        }

        [Test]
        public void Home_SignInAndSignUpLinks_Visibility()
        {
            Go.To<HomePage>().
                SignIn.Should.Exist().
                SignUp.Should.Exist().
                SignIn.ClickAndGo().
                    Email.Set(Config.Account.Email).
                    Password.Set(Config.Account.Password).
                    SignIn().
                        Menu.Home().
                SignIn.Should.Not.Exist().
                SignUp.Should.Not.Exist().
                Menu.Account.SignOut().
                    Menu.Home().
                SignIn.Should.Exist().
                SignUp.Should.Exist();
        }
    }
}
