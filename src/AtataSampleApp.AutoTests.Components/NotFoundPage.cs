using Atata;

namespace AtataSampleApp.AutoTests
{
    using _ = NotFoundPage;

    [Name("Page Not Found")]
    [VerifyTitle]
    [VerifyH1(TermMatch.Contains)]
    public class NotFoundPage : AppPage<_>
    {
    }
}
