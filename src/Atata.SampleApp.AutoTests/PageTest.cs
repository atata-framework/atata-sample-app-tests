using NUnit.Framework;

namespace Atata.SampleApp.AutoTests
{
    [TestFixture]
    public class PageTest : AutoTest
    {
        [Test]
        public void Settings()
        {
            Login().
                Menu.Account.Settings();
        }
    }
}
