namespace AtataSampleApp.UITests;

using _ = UserEditWindow;

[WaitFor(Until.MissingOrHidden, TriggerEvents.PageObjectTransitionOut)]
public sealed class UserEditWindow : BSModal<_>
{
    public GeneralTabPane General { get; private set; }

    public AdditionalTabPane Additional { get; private set; }

    [Term("Save", "Create")]
    public ButtonDelegate<UsersPage, _> Save { get; private set; }

    public ButtonDelegate<UsersPage, _> Cancel { get; private set; }

    [FindByClass]
    public ButtonDelegate<UsersPage, _> Close { get; private set; }

    public ValidationMessageList<_> ValidationMessages { get; private set; }

    [TypesTextUsingScript(TargetType = typeof(EditableTextField<,>))]
    public sealed class GeneralTabPane : BSTabPane<_>
    {
        public TextInput<_> FirstName { get; private set; }

        public TextInput<_> LastName { get; private set; }

        [RandomizeStringSettings("{0}@mail.com")]
        public TextInput<_> Email { get; private set; }

        public Select<Office?, _> Office { get; private set; }

        [FindByName]
        public RadioButtonList<Gender?, _> Gender { get; private set; }
    }

    public sealed class AdditionalTabPane : BSTabPane<_>
    {
        public DateInput<_> Birthday { get; private set; }

        public TextArea<_> Notes { get; private set; }
    }
}
