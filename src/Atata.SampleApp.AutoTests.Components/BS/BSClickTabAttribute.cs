using System;

namespace Atata.SampleApp.AutoTests
{
    public class BSClickTabAttribute : TriggerAttribute
    {
        public BSClickTabAttribute(TriggerEvents on = TriggerEvents.BeforeAnyAction, TriggerPriority priority = TriggerPriority.Medium)
            : base(on, priority)
        {
        }

        protected override void Execute<TOwner>(TriggerContext<TOwner> context)
        {
            var tabPanelControl = context.Component.GetAncestorOrSelf<BSTabPane<TOwner>>();
            if (tabPanelControl == null)
                throw new InvalidOperationException("Cannot find tab pane.");

            string tabPaneId = tabPanelControl.Attributes.GetValue("id");
            var findAttribute = new FindByInnerXPathAttribute($".//a[@href='#{tabPaneId}']");

            // TODO: CreateControl in Owner.
            var tab = ((IUIComponent<TOwner>)tabPanelControl).Parent.Controls.Create<BSTab<TOwner>>(context.Component.Parent.ComponentName, findAttribute);

            if (!tab.IsActive)
                tab.Click();
        }
    }
}
