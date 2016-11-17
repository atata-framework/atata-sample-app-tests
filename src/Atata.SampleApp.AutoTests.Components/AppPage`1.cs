namespace Atata.SampleApp.AutoTests
{
    public class AppPage<_> : Page<_>
        where _ : AppPage<_>
    {
        public MainMenu Menu { get; private set; }

        public class MainMenu : BSNavbar<_>
        {
            public LinkDelegate<UsersPage, _> Users { get; private set; }

            public AccountDropdown Account { get; private set; }

            public class AccountDropdown : BSDropdown<_>
            {
                public LinkDelegate<SignInPage, _> SignOut { get; private set; }

                public LinkDelegate<SettingsPage, _> Settings { get; private set; }
            }
        }
    }
}
