namespace Atata.SampleApp.AutoTests
{
    [ControlDefinition("ul[contains(concat(' ', normalize-space(@class), ' '), ' nav-tabs ')]/li", ComponentTypeName = "Tab", IgnoreNameEndings = "Tab")]
    public class BSTab<_> : Control<_>
        where _ : PageObject<_>
    {
        // Use Atata's HasClass method.
        public bool IsActive
        {
            get { return Scope.GetAttribute("class").Contains("active"); }
        }
    }
}
