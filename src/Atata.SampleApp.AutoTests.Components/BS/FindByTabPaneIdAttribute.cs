using System.Text;

namespace Atata.SampleApp.AutoTests
{
    public class FindByTabPaneIdAttribute : TermFindAttribute
    {
        public FindByTabPaneIdAttribute(TermCase termCase)
            : base(termCase)
        {
        }

        public FindByTabPaneIdAttribute(TermMatch match, TermCase termCase = TermCase.Inherit)
            : base(match, termCase)
        {
        }

        public FindByTabPaneIdAttribute(TermMatch match, params string[] values)
            : base(match, values)
        {
        }

        public FindByTabPaneIdAttribute(params string[] values)
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
