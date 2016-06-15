using _ = Atata.SampleApp.AutoTests.UserEditWindow;

namespace Atata.SampleApp.AutoTests
{
    public class UserEditWindow : PopupWindow<_>
    {
        public UserEditWindow(string userName = null)
        {
        }

        public TextInput<_> FirstName { get; private set; }

        public TextInput<_> LastName { get; private set; }

        [RandomizeStringSettings("{0}@mail.com")]
        public TextInput<_> Email { get; private set; }

        public Select<Office?, _> Office { get; private set; }

        [FindByName]
        public RadioButtonList<Sex?, _> Sex { get; private set; }

        public DateInput<_> Birthday { get; private set; }

        [Term("Save", "Create")]
        public Button<UsersPage, _> Save { get; private set; }
    }
}
