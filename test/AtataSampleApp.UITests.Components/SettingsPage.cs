namespace AtataSampleApp.UITests;

using _ = SettingsPage;

[VerifyTitle]
[VerifyContent("Should contain some settings")]
public sealed class SettingsPage : AppPage<_>
{
}
