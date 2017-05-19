using Atata;
using _ = AtataSampleApp.AutoTests.NotFoundPage;

namespace AtataSampleApp.AutoTests
{
    [Name("Page Not Found")]
    [VerifyTitle]
    [VerifyH1(TermMatch.Contains)]
    public class NotFoundPage : AppPage<_>
    {
    }
}
