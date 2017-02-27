using NUnit.Framework;

namespace Atata.SampleApp.AutoTests
{
    public class HomeTest : AutoTest
    {
        [Test]
        public void Home()
        {
            Go.To<HomePage>().
                PageUrl.Should.EndWith("/#!/");
        }
    }
}
