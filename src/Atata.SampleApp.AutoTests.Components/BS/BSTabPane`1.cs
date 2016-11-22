namespace Atata.SampleApp.AutoTests
{
    [ControlDefinition("div", ContainingClass = "tab-pane", ComponentTypeName = "tab pane", IgnoreNameEndings = "Tab,TabPane,TabPanel", Visibility = Visibility.Any)]
    [BSClickTab(AppliesTo = TriggerScope.Children)]
    public class BSTabPane<_> : Control<_>
        where _ : PageObject<_>
    {
    }
}
