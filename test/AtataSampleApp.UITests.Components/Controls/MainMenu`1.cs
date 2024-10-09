namespace AtataSampleApp.UITests;

public sealed class MainMenu<TOwner> : BSNavbar<TOwner>
    where TOwner : PageObject<TOwner>
{
    [FindByClass("navbar-header")]
    public LinkDelegate<HomePage, TOwner> Home { get; private set; }

    public LinkDelegate<PlansPage, TOwner> Plans { get; private set; }

    public LinkDelegate<UsersPage, TOwner> Users { get; private set; }

    public LinkDelegate<SignInPage, TOwner> SignIn { get; private set; }

    public LinkDelegate<SignUpPage, TOwner> SignUp { get; private set; }

    public AccountDropdown Account { get; private set; }

    public sealed class AccountDropdown : BSDropdown<TOwner>
    {
        public LinkDelegate<SignInPage, TOwner> SignOut { get; private set; }

        public LinkDelegate<SettingsPage, TOwner> Settings { get; private set; }
    }
}
