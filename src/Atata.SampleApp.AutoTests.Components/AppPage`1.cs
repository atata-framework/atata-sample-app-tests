namespace Atata.SampleApp.AutoTests
{
    public class AppPage<T> : Page<T>
        where T : AppPage<T>
    {
    }
}
