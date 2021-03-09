using Atata;

namespace AtataSampleApp.UITests
{
    using _ = ForbiddenPage;

    [VerifyTitle]
    [VerifyH1(TermMatch.Contains)]
    public class ForbiddenPage : AppPage<_>
    {
        public LinkDelegate<SignInPage, _> SignIn { get; private set; }
    }
}
