using _ = Atata.SampleApp.AutoTests.SignInPage;

namespace Atata.SampleApp.AutoTests
{
    [VerifyTitle]
    [NavigateTo("signin")]
    public class SignInPage : Page<_>
    {
        public TextInput<_> Email { get; private set; }
        public TextInput<_> Password { get; private set; }

        public Button<UsersPage, _> SignIn { get; private set; }
    }
}
