namespace Atata.SampleApp.AutoTests
{
    [ControlDefinition(ContainingClass = "navbar", ComponentTypeName = "navbar", IgnoreNameEndings = "Menu,Navbar")]
    public class BSNavbar<_> : Control<_>
        where _ : PageObject<_>
    {
    }
}
