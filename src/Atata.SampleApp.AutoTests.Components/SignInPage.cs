using _ = Atata.SampleApp.AutoTests.SignInPage;

namespace Atata.SampleApp.AutoTests
{
    [VerifyTitle]
    [VerifyH1]
    [Url("signin")]
    public class SignInPage : Page<_>
    {
        public TextInput<_> Email { get; private set; }

        public PasswordInput<_> Password { get; private set; }

        public ButtonDelegate<UsersPage, _> SignIn { get; private set; }

        public ValidationMessageList<_> ValidationMessages { get; private set; }
    }
}
