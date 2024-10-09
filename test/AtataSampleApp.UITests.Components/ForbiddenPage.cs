namespace AtataSampleApp.UITests;

using _ = ForbiddenPage;

public class ForbiddenPage : AppPage<_>
{
    public Link<SignInPage, _> SignIn { get; private set; }
}
