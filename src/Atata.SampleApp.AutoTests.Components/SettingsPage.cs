using _ = Atata.SampleApp.AutoTests.SettingsPage;

namespace Atata.SampleApp.AutoTests
{
    [VerifyTitle]
    [VerifyContent("Should contain some settings")]
    public class SettingsPage : Page<_>
    {
    }
}
