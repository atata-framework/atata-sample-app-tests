using NUnit.Framework;

namespace Atata.SampleApp.AutoTests
{
    public class PageTest : AutoTest
    {
        [Test]
        public void Page_Settings()
        {
            Login().
                Menu.Account.Settings();
        }

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
