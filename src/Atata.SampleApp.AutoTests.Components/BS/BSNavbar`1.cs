namespace Atata.SampleApp.AutoTests
{
    [ControlDefinition("*[contains(concat(' ', normalize-space(@class), ' '), ' navbar ')]", ComponentTypeName = "navbar", IgnoreNameEndings = "Menu,Navbar")]
    public class BSNavbar<_> : Control<_>
        where _ : PageObject<_>
    {
    }
}
