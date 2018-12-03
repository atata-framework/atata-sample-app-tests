using Atata;

namespace AtataSampleApp.UITests
{
    using _ = SettingsPage;

    [VerifyTitle]
    [VerifyContent("Should contain some settings")]
    public class SettingsPage : AppPage<_>
    {
    }
}
