using System;

namespace Atata.SampleApp.AutoTests
{
    public class BSClickTabAttribute : TriggerAttribute
    {
        public BSClickTabAttribute(TriggerEvents on = TriggerEvents.BeforeAnyAction, TriggerPriority priority = TriggerPriority.Medium, TriggerScope appliesTo = TriggerScope.Self)
            : base(on, priority, appliesTo)
        {
        }

        public override void Execute<TOwner>(TriggerContext<TOwner> context)
        {
            var tabPanelControl = GetAncestorOrSelf<TOwner, BSTabPane<TOwner>>(context.Component);
            if (tabPanelControl == null)
                throw new InvalidOperationException("Cannot find tab pane.");

            string tabPaneId = tabPanelControl.ScopeLocator.GetElement().GetAttribute("id");
            var findAttribute = new FindByTabPaneIdAttribute("#" + tabPaneId.ToString(TermFormat.Kebab));

            // TODO: CreateControl in Owner.
            var tab = tabPanelControl.Parent.CreateControl<BSTab<TOwner>>(context.Component.ComponentName, findAttribute);

            if (!tab.IsActive)
                tab.Click();
        }

        // TODO: Move to TriggerContext.
        private IUIComponent<TOwner> GetAncestorOrSelf<TOwner, TComponentToFind>(IUIComponent<TOwner> component)
            where TOwner : PageObject<TOwner>
            where TComponentToFind : IUIComponent<TOwner>
        {
            return component is TComponentToFind ?
                (TComponentToFind)component :
                component.Parent != null ?
                    GetAncestorOrSelf<TOwner, TComponentToFind>(component.Parent) :
                    null;
        }
    }
}
