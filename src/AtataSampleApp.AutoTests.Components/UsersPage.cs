using Atata;
using _ = AtataSampleApp.AutoTests.UsersPage;

namespace AtataSampleApp.AutoTests
{
    [VerifyTitle]
    [VerifyH1]
    public class UsersPage : AppPage<_>
    {
        public ButtonDelegate<UserEditWindow, _> New { get; private set; }

        public Table<UserTableRow, _> Users { get; private set; }

        public class UserTableRow : TableRow<_>
        {
            public Text<_> FirstName { get; private set; }

            public Text<_> LastName { get; private set; }

            public Text<_> Email { get; private set; }

            public Content<Office, _> Office { get; private set; }

            public LinkDelegate<UserDetailsPage, _> View { get; private set; }

            public ButtonDelegate<UserEditWindow, _> Edit { get; private set; }

            [CloseConfirmBox]
            public ButtonDelegate<_> Delete { get; private set; }
        }
    }
}
