using Atata;
using NUnit.Framework;

namespace AtataSampleApp.UITests
{
    public class PageTests : UITestFixture
    {
        [Test]
        public void NotFound()
        {
            Go.To<NotFoundPage>(url: "not-found-page");
        }

        [Test]
        public void Forbidden()
        {
            Go.To<ForbiddenPage>(url: "users")
                .SignIn();
        }
    }
}
