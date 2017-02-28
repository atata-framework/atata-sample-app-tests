using _ = Atata.SampleApp.AutoTests.SignUpPage;

namespace Atata.SampleApp.AutoTests
{
    [VerifyTitle]
    [VerifyH1]
    [Url("signup")]
    public class SignUpPage : AppPage<_>
    {
        public TextInput<_> FirstName { get; private set; }

        public TextInput<_> LastName { get; private set; }

        [RandomizeStringSettings("{0}@mail.com")]
        public TextInput<_> Email { get; private set; }

        public PasswordInput<_> Password { get; private set; }

        public Select<Office?, _> Office { get; private set; }

        [FindByName]
        public RadioButtonList<Gender?, _> Gender { get; private set; }

        [FindByLabel(TermMatch.StartsWith, "I agree to")]
        public CheckBox<_> Agreement { get; private set; }

        public ButtonDelegate<UserDetailsPage, _> SignUp { get; private set; }

        public ValidationMessageList<_> ValidationMessages { get; private set; }
    }
}
