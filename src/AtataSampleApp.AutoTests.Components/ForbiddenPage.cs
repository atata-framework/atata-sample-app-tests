using Atata;
using _ = AtataSampleApp.AutoTests.ForbiddenPage;

namespace AtataSampleApp.AutoTests
{
    [VerifyTitle]
    [VerifyH1(TermMatch.Contains)]
    public class ForbiddenPage : AppPage<_>
    {
        public LinkDelegate<SignInPage, _> SignIn { get; private set; }
    }
}
