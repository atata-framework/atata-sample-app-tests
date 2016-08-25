using System;

namespace Atata.SampleApp.AutoTests
{
    public class ValidationMessageList<TOwner> : ControlList<ValidationMessage<TOwner>, TOwner>
        where TOwner : PageObject<TOwner>
    {
        public ValidationMessage<TOwner> For(Func<TOwner, Control<TOwner>> controlSelector)
        {
            return null;
        }
    }
}
