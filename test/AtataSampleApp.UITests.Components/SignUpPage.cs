using Atata;

namespace AtataSampleApp.UITests
{
    using _ = SignUpPage;

    [Url("signup")]
    [VerifyTitle]
    [VerifyH1]
    public class SignUpPage : AppPage<_>
    {
        public TextInput<_> FirstName { get; private set; }

        public TextInput<_> LastName { get; private set; }

        [RandomizeStringSettings("{0}@mail.com")]
        public TextInput<_> Email { get; private set; }

        public PasswordInput<_> Password { get; private set; }

        [FindByLabel("I agree to terms of service and privacy policy")]
        public CheckBox<_> Agreement { get; private set; }

        public ButtonDelegate<UserDetailsPage, _> SignUp { get; private set; }

        public ValidationMessageList<_> ValidationMessages { get; private set; }
    }
}
