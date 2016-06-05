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
        }
    }
}
