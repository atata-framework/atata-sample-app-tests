namespace AtataSampleApp.UITests;

public abstract class TestSuite : AtataTestSuite
{
    protected GlobalConfig Config =>
        Context.State.Get<GlobalConfig>();

    protected UsersPage Login() =>
        Go.To<SignInPage>()
            .Email.Set(Config.Account.Email)
            .Password.Set(Config.Account.Password)
            .SignIn();
}
