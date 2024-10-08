﻿namespace AtataSampleApp.UITests;

using _ = PlansPage;

[Url("plans")]
[VerifyTitle]
[VerifyH1]
[VerifyContent("Please choose your payment plan")]
public sealed class PlansPage : AppPage<_>
{
    public ControlList<PlanItem, _> PlanItems { get; private set; }

    [ControlDefinition("div", ContainingClass = "plan-item", ComponentTypeName = "plan item")]
    public sealed class PlanItem : Control<_>
    {
        public H3<_> Title { get; private set; }

        [FindByClass]
        public Currency<_> Price { get; private set; }

        [FindByClass("projects-num")]
        public Number<_> NumberOfProjects { get; private set; }

        public ControlList<TextListItem<_>, _> Features { get; private set; }
    }
}
