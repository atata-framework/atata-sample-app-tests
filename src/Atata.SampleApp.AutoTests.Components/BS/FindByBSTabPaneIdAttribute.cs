using System.Text;

namespace Atata.SampleApp.AutoTests
{
    public class FindByBSTabPaneIdAttribute : TermFindAttribute
    {
        public FindByBSTabPaneIdAttribute(TermCase termCase)
            : base(termCase)
        {
        }

        public FindByBSTabPaneIdAttribute(TermMatch match, TermCase termCase = TermCase.Inherit)
            : base(match, termCase)
        {
        }

        public FindByBSTabPaneIdAttribute(TermMatch match, params string[] values)
            : base(match, values)
        {
        }

        public FindByBSTabPaneIdAttribute(params string[] values)
            : base(values)
        {
        }

        protected override TermCase DefaultCase
        {
            get { return TermCase.Kebab; }
        }

        public override IComponentScopeLocateStrategy CreateStrategy(UIComponentMetadata metadata)
        {
            return new FindByTabPaneIdStrategy();
        }

        public class FindByTabPaneIdStrategy : XPathComponentScopeLocateStrategy
        {
            protected override void BuildXPath(StringBuilder builder, ComponentScopeLocateOptions options)
            {
                builder.AppendFormat(
                    "[.//a[{0}]]",
                    options.GetTermsXPathCondition("@href"));
            }
        }
    }
}
