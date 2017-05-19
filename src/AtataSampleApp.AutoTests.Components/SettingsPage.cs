using Atata;
using _ = AtataSampleApp.AutoTests.SettingsPage;

namespace AtataSampleApp.AutoTests
{
    [VerifyTitle]
    [VerifyContent("Should contain some settings")]
    public class SettingsPage : AppPage<_>
    {
    }
}
