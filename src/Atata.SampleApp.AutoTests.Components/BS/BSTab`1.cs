namespace Atata.SampleApp.AutoTests
{
    [ControlDefinition("ul[contains(concat(' ', normalize-space(@class), ' '), ' nav-tabs ')]/li", ComponentTypeName = "tab", IgnoreNameEndings = "Tab")]
    public class BSTab<_> : Control<_>
        where _ : PageObject<_>
    {
        public bool IsActive
        {
            get { return Scope.HasClass("active"); }
        }
    }
}
