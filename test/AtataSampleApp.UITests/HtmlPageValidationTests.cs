using Atata;
using NUnit.Framework;

namespace AtataSampleApp.UITests
{
    public class HtmlPageValidationTests : UITestFixture
    {
        [TestCase("/")]
        [TestCase("signin")]
        [TestCase("signup")]
        [TestCase("plans")]
        public void Validate(string url)
        {
            Go.To<AppPage>(url: url)
                .Header.WaitTo.BeVisible()
                .ValidateHtml();
        }
    }
}
