using _ = Atata.SampleApp.AutoTests.NotFoundPage;

namespace Atata.SampleApp.AutoTests
{
    [Name("Page Not Found")]
    [VerifyTitle]
    [VerifyH1(TermMatch.Contains)]
    public class NotFoundPage : AppPage<_>
    {
    }
}
