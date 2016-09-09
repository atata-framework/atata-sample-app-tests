using System.Text;
using OpenQA.Selenium;

namespace Atata.SampleApp.AutoTests
{
    [PageObjectDefinition(ComponentTypeName = "modal", IgnoreNameEndings = "PopupWindow,Window,Popup,Modal")]
    public abstract class BSModal<TOwner> : PopupWindow<TOwner>
        where TOwner : BSModal<TOwner>
    {
        protected BSModal(params string[] windowTitleValues)
            : base(windowTitleValues)
        {
        }

        protected override By CreateScopeBy()
        {
            StringBuilder xPathBuilder = new StringBuilder(
                "//div[contains(concat(' ', normalize-space(@class), ' '), ' modal ')]");

            if (CanFindByWindowTitle)
            {
                xPathBuilder.AppendFormat(
                    "[.//*[contains(concat(' ', normalize-space(@class), ' '), ' modal-title ')][{0}]]",
                    WindowTitleMatch.CreateXPathCondition(WindowTitleValues));
            }

            return By.XPath(xPathBuilder.ToString()).PopupWindow(TermResolver.ToDisplayString(WindowTitleValues));
        }
    }
}
