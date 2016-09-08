using OpenQA.Selenium;
using _ = Atata.SampleApp.AutoTests.UserEditWindow;

namespace Atata.SampleApp.AutoTests
{
    public class UserEditWindow : PopupWindow<_>
    {
        // TODO: Review constructor.
        public UserEditWindow(string userName = null)
        {
        }

        [FindById(TermCase.Lower)]
        public GeneralTabPane General { get; private set; }

        [FindById(TermCase.Lower)]
        public AdditionalTabPane Additional { get; private set; }

        [Term("Save", "Create")]
        public Button<UsersPage, _> Save { get; private set; }

        public ValidationMessageList<_> ValidationMessages { get; private set; }

        protected override By CreateScopeBy()
        {
            return By.TagName("body");
        }

        public class GeneralTabPane : BSTabPane<_>
        {
            public TextInput<_> FirstName { get; private set; }

            public TextInput<_> LastName { get; private set; }

            [RandomizeStringSettings("{0}@mail.com")]
            public TextInput<_> Email { get; private set; }

            public Select<Office?, _> Office { get; private set; }

            [FindByName]
            public RadioButtonList<Sex?, _> Sex { get; private set; }
        }

        public class AdditionalTabPane : BSTabPane<_>
        {
            public DateInput<_> Birthday { get; private set; }

            public TextArea<_> Notes { get; private set; }
        }
    }
}
