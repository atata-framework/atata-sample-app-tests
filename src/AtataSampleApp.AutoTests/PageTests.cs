using Atata;
using NUnit.Framework;

namespace AtataSampleApp.AutoTests
{
    public class PageTests : UITestFixture
    {
        [Test]
        public void Page_NotFound()
        {
            Go.To<NotFoundPage>(url: "not-found-page");
        }

        [Test]
        public void Page_Forbidden()
        {
            Go.To<ForbiddenPage>(url: "users").
                SignIn();
        }
    }
}
