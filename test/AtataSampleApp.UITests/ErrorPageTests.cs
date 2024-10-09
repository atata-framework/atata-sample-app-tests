namespace AtataSampleApp.UITests;

public class ErrorPageTests : UITestFixture
{
    [Test]
    public void NotFound()
    {
        const string expectedTitle = "Page Not Found";

        Go.To<AppPage>(url: "not-found-page")
            .AggregateAssert(x => x
                .PageTitle.Should.Contain(expectedTitle)
                .Header.Should.ContainAll("404", expectedTitle));
    }

    [Test]
    public void Forbidden()
    {
        const string expectedTitle = "Forbidden";

        Go.To<ForbiddenPage>(url: "users")
            .AggregateAssert(x => x
                .PageTitle.Should.Contain(expectedTitle)
                .Header.Should.Contain(expectedTitle)
                .Content.Should.Contain("Please sign in to access the page")
                .SignIn.Should.BeVisible());
    }
}
