namespace Atata.SampleApp.AutoTests
{
    public class AppPage<_> : Page<_>
        where _ : AppPage<_>
    {
        public MainMenu Menu { get; private set; }

        public class MainMenu : BSNavbar<_>
        {
            public Link<UsersPage, _> Users { get; private set; }

            [FindByContent(TermMatch.StartsWith)]
            public AccountDropdown Account { get; private set; }

            public class AccountDropdown : BSDropdown<_>
            {
                public Link<SignInPage, _> SignOut { get; private set; }

                public Link<SettingsPage, _> Settings { get; private set; }
            }
        }
    }
}
