namespace AtataSampleApp.UITests;

[WaitForDocumentReadyState(Priority = TriggerPriority.Highest)]
public abstract class AppPage<TOwner> : Page<TOwner>
    where TOwner : AppPage<TOwner>
{
    public MainMenu<TOwner> Menu { get; private set; }

    [FindFirst]
    public H1<TOwner> Header { get; private set; }
}
