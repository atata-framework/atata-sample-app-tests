namespace Atata.SampleApp.AutoTests
{
    [ControlDefinition("*[contains(concat(' ', normalize-space(@class), ' '), ' dropdown ')]", ComponentTypeName = "dropdown", IgnoreNameEndings = "DropdownButton,DropDownButton,Dropdown,DropDown,Button")]
    [ControlFinding(FindTermBy.ChildContent)]
    [ClickParent(AppliesTo = TriggerScope.Children)]
    public class BSDropdown<_> : ClickableControl<_>
        where _ : PageObject<_>
    {
    }
}
