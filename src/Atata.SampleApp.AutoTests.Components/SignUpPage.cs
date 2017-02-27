using _ = Atata.SampleApp.AutoTests.SignUpPage;

namespace Atata.SampleApp.AutoTests
{
    [VerifyTitle]
    [VerifyH1]
    [Url("signup")]
    public class SignUpPage : AppPage<_>
    {
    }
}
