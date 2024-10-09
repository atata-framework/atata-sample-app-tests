namespace AtataSampleApp.UITests;

using _ = ForbiddenPage;

public sealed class ForbiddenPage : AppPage<_>
{
    public Link<SignInPage, _> SignIn { get; private set; }
}
