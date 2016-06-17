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
            var tab = context.Component.Parent.CreateControl<BSTab<TOwner>>(context.Component.ComponentName, new FindByXPathAttribute(""));

            if (!tab.IsActive)
                tab.Click();
        }
    }
}
