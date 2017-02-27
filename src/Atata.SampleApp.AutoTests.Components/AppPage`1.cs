using Atata.Bootstrap;

namespace Atata.SampleApp.AutoTests
{
    public class AppPage<_> : Page<_>
        where _ : AppPage<_>
    {
        public MainMenu Menu { get; private set; }

        public class MainMenu : BSNavbar<_>
        {
            [FindByClass("navbar-header")]
            public LinkDelegate<HomePage, _> Home { get; private set; }

            public LinkDelegate<PlansPage, _> Plans { get; private set; }

            public LinkDelegate<UsersPage, _> Users { get; private set; }

            public LinkDelegate<SignInPage, _> SignIn { get; private set; }

            public LinkDelegate<SignUpPage, _> SignUp { get; private set; }

            public AccountDropdown Account { get; private set; }

            public class AccountDropdown : BSDropdown<_>
            {
                public LinkDelegate<SignInPage, _> SignOut { get; private set; }

                public LinkDelegate<SettingsPage, _> Settings { get; private set; }
            }
        }
    }
}
