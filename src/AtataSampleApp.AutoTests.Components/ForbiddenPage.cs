using _ = Atata.SampleApp.AutoTests.ForbiddenPage;

namespace Atata.SampleApp.AutoTests
{
    [VerifyTitle]
    [VerifyH1(TermMatch.Contains)]
    public class ForbiddenPage : AppPage<_>
    {
        public LinkDelegate<SignInPage, _> SignIn { get; private set; }
    }
}
