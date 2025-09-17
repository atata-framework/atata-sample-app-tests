namespace AtataSampleApp.UITests;

public sealed class HtmlPageValidationTests : TestSuite
{
    [TestCase("/")]
    [TestCase("signin")]
    [TestCase("signup")]
    [TestCase("plans")]
    public void Validate(string url) =>
        Go.To<AppPage>(url: url)
            .ValidateHtml();
}
