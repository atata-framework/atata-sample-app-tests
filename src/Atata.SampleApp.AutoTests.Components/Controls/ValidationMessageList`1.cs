using System;
using OpenQA.Selenium;

namespace Atata.SampleApp.AutoTests
{
    public class ValidationMessageList<TOwner> : ControlList<ValidationMessage<TOwner>, TOwner>
        where TOwner : PageObject<TOwner>
    {
        public ValidationMessage<TOwner> For(Func<TOwner, IControl<TOwner>> controlSelector)
        {
            var validationMessageDefinition = UIComponentResolver.GetControlDefinition(typeof(ValidationMessage<TOwner>));

            IControl<TOwner> boundControl = controlSelector(Component.Owner);

            DynamicScopeLocator scopeLocator = new DynamicScopeLocator(
                so => boundControl.ScopeLocator.GetElement(so)?.Get(By.XPath("ancestor::" + validationMessageDefinition.ScopeXPath).With(so)));

            return Component.Controls.Create<ValidationMessage<TOwner>>(boundControl.ComponentName, scopeLocator);
        }
    }
}
