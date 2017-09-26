using Atata;

namespace AtataSampleApp.AutoTests
{
    using _ = SettingsPage;

    [VerifyTitle]
    [VerifyContent("Should contain some settings")]
    public class SettingsPage : AppPage<_>
    {
    }
}
