using Atata;
using Atata.Bootstrap;

namespace AtataSampleApp.UITests
{
    using _ = UserEditWindow;

    [InvokeMethod(nameof(WaitUntilHidden), TriggerEvents.DeInit)]
    public class UserEditWindow : BSModal<_>
    {
        public GeneralTabPane General { get; private set; }

        public AdditionalTabPane Additional { get; private set; }

        [Term("Save", "Create")]
        public ButtonDelegate<UsersPage, _> Save { get; private set; }

        public ButtonDelegate<UsersPage, _> Cancel { get; private set; }

        [FindByClass]
        public ButtonDelegate<UsersPage, _> Close { get; private set; }

        public ValidationMessageList<_> ValidationMessages { get; private set; }

        private void WaitUntilHidden()
        {
            Wait(Until.MissingOrHidden);
        }

        public class GeneralTabPane : BSTabPane<_>
        {
            public TextInput<_> FirstName { get; private set; }

            public TextInput<_> LastName { get; private set; }

            [RandomizeStringSettings("{0}@mail.com")]
            public TextInput<_> Email { get; private set; }

            public Select<Office?, _> Office { get; private set; }

            [FindByName]
            public RadioButtonList<Gender?, _> Gender { get; private set; }
        }

        public class AdditionalTabPane : BSTabPane<_>
        {
            public DateInput<_> Birthday { get; private set; }

            public TextArea<_> Notes { get; private set; }
        }
    }
}
