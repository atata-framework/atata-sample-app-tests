using _ = Atata.SampleApp.AutoTests.PlansPage;

namespace Atata.SampleApp.AutoTests
{
    [VerifyTitle]
    [VerifyH1]
    [Url("plans")]
    [VerifyContent("The provided information is just for testing purposes")]
    public class PlansPage : AppPage<_>
    {
        public ControlList<PlanItem, _> PlanItems { get; private set; }

        [ControlDefinition("div", ContainingClass = "plan-item", ComponentTypeName = "plan item")]
        public class PlanItem : Control<_>
        {
            public H3<_> Title { get; private set; }

            [FindByClass]
            public PlanPrice<_> Price { get; private set; }

            [FindByClass("projects-num")]
            public Number<_> NumberOfProjects { get; private set; }
        }
    }
}
