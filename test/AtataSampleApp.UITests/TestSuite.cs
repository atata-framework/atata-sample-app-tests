namespace AtataSampleApp.UITests;

public abstract class TestSuite : AtataTestSuite
{
    protected GlobalConfig Config =>
        Context.State.Get<GlobalConfig>();

    protected static UsersPage Login(UserCredentials credentials) =>
        Go.To<SignInPage>()
            .Email.Set(credentials.Email)
            .Password.Set(credentials.Password)
            .SignIn();

    protected UsersPage Login() =>
        Login(Config.Account);
}
