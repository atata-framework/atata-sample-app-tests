using Atata;

namespace AtataSampleApp.UITests;

using _ = SignInPage;

[Url("signin")]
[VerifyTitle]
[VerifyH1]
public class SignInPage : AppPage<_>
{
    public TextInput<_> Email { get; private set; }

    public PasswordInput<_> Password { get; private set; }

    public ButtonDelegate<UsersPage, _> SignIn { get; private set; }

    public ValidationMessageList<_> ValidationMessages { get; private set; }
}
