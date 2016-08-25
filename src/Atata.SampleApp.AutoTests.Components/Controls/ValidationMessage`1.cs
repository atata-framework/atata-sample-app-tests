namespace Atata.SampleApp.AutoTests
{
    [ControlDefinition("span", ContainingClass = "help-block", ComponentTypeName = "validation message")]
    public class ValidationMessage<TOwner> : Text<TOwner>
        where TOwner : PageObject<TOwner>
    {
    }
}
