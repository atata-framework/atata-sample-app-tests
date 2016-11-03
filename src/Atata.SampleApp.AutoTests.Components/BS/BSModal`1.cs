namespace Atata.SampleApp.AutoTests
{
    [PageObjectDefinition("div", ContainingClass = "modal", ComponentTypeName = "modal", IgnoreNameEndings = "PopupWindow,Window,Popup,Modal")]
    [WindowTitleElementDefinition(ContainingClass = TitleClassName)]
    public abstract class BSModal<TOwner> : PopupWindow<TOwner>
        where TOwner : BSModal<TOwner>
    {
        private const string TitleClassName = "modal-title";

        protected BSModal(params string[] windowTitleValues)
            : base(windowTitleValues)
        {
        }

        [FindByClass(TitleClassName)]
        public Text<TOwner> ModalTitle { get; private set; }
    }
}
