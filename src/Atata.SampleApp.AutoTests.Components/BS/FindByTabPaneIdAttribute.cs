using System.Text;

namespace Atata.SampleApp.AutoTests
{
    public class FindByTabPaneIdAttribute : TermFindAttribute
    {
        public FindByTabPaneIdAttribute(TermMatch match)
            : base(match)
        {
        }

        public FindByTabPaneIdAttribute(TermFormat format, TermMatch match = TermMatch.Inherit)
            : base(format, match)
        {
        }

        public FindByTabPaneIdAttribute(string value, TermMatch match)
            : base(value, match)
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
