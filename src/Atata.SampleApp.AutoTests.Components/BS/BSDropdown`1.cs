namespace Atata.SampleApp.AutoTests
{
    [ControlDefinition(ContainingClass = "dropdown", ComponentTypeName = "dropdown", IgnoreNameEndings = "DropdownButton,DropDownButton,Dropdown,DropDown,Button")]
    [ControlFinding(FindTermBy.ChildContent)]
    [ClickParent(AppliesTo = TriggerScope.Children)]
    public class BSDropdown<_> : ClickableControl<_>
        where _ : PageObject<_>
    {
    }
}
