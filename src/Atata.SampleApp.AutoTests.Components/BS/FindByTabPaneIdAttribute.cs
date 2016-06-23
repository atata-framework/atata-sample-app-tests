using System.Text;

namespace Atata.SampleApp.AutoTests
{
    public class FindByTabPaneIdAttribute : TermFindAttribute
    {
        public FindByTabPaneIdAttribute(TermFormat format)
            : base(format)
        {
        }

        public FindByTabPaneIdAttribute(TermMatch match, TermFormat format = TermFormat.Inherit)
            : base(match, format)
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

        protected override TermFormat DefaultFormat
        {
            get { return TermFormat.Kebab; }
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
