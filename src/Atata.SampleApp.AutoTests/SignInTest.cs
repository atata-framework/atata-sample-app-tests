using NUnit.Framework;

namespace Atata.SampleApp.AutoTests
{
    [TestFixture]
    public class SignInTest : AutoTest
    {
        [Test]
        public void SignIn()
        {
            Login();
        }

        [Test]
        public void SignIn_Validation()
        {
            Go.To<SignInPage>().
                SignIn.Click().
                ValidationMessages[x => x.Email].Should.Equal(ValidationMessages.Required).
                ValidationMessages[x => x.Password].Should.Equal(ValidationMessages.Required).
                Email.Set(Config.Account.Email).
                Password.Set(Config.Account.Password + "!").
                SignIn.Click().
                ValidationMessages[x => x.Password].Should.Equal("or Email is invalid");
        }
    }
}
