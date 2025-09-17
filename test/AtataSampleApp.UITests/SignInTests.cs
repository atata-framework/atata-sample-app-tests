namespace AtataSampleApp.UITests;

public sealed class SignInTests : TestSuite
{
    [Test]
    public void SignIn() =>
        Login();

    [Test]
    public void Validation_Required() =>
        Go.To<SignInPage>()
            .SignIn.Click()
            .ValidationMessages[x => x.Email].Should.BeRequired()
            .ValidationMessages[x => x.Password].Should.BeRequired()
            .Email.Set(Config.Account.Email)
            .Password.Set(Config.Account.Password)
            .SignIn();

    [Test]
    public void Validation_InvalidPassword() =>
        Go.To<SignInPage>()
            .Email.Set(Config.Account.Email)
            .Password.Set(Config.Account.Password + "!")
            .SignIn.Click()
            .ValidationMessages.Should.Contain(TermMatch.Contains, "invalid")
            .Password.Set(Config.Account.Password)
            .SignIn();
}
