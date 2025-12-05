namespace AtataSampleApp.UITests;

[StartSessionAndShare(typeof(WebDriverSession))]
public sealed class NewUserTests : TestSuite
{
    [OneTimeSetUp]
    public void SetUpPage() =>
        Login();

    [Test]
    [Repeat(6)]
    public void GoToNewUserModal() =>
        Go.To<UsersPage>()
            .New()
                .General.FirstName.Type(Randomizer.GetString())
                .General.FirstName.Should.AtOnce.Not.BeEmpty();

    [Test]
    [Repeat(6)]
    public void Create() =>
        Go.To<UsersPage>()
            .New()
                .General.FirstName.SetRandom(out string firstName)
                .General.LastName.SetRandom(out string lastName)
                .General.Email.SetRandom(out string email)
                .General.Office.SetRandom(out Office office)
                .General.Gender.SetRandom(out Gender gender)
                .Save()
            .GetUserRow(email).View()
                .AggregateAssert(x => x
                    .Header.Should.Be($"{firstName} {lastName}")
                    .Email.Should.Be(email)
                    .Office.Should.Be(office)
                    .Gender.Should.Be(gender)
                    .Birthday.Should.Not.BeVisible()
                    .Notes.Should.Not.BeVisible());

    [Test]
    [Repeat(6)]
    public void GoToCalculationsPage()
    {
        var control = Go.To<OrdinaryPage>(url: "/calculations")
            .Find<TextInput<OrdinaryPage>>(new FindFirstAttribute());

        control.Set(Randomizer.GetString());
        control.Should.AtOnce.Not.BeEmpty();
    }

    [Test]
    [Repeat(100)]
    public void Create_Validation_RealTime() =>
        Go.To<UsersPage>()
            .New()
                .ValidationMessages.Should.BeEmpty()

                .General.FirstName.Click()
                .General.LastName.Click()
                .ValidationMessages.Should.HaveCount(1)
                .ValidationMessages[x => x.General.FirstName].Should.BeRequired()
                .General.FirstName.Set("a")
                .General.LastName.Set("x")
                .General.FirstName.Click()
                .ValidationMessages.Should.HaveCount(2)
                .ValidationMessages[x => x.General.FirstName].Should.HaveMinLength(2)
                .ValidationMessages[x => x.General.LastName].Should.HaveMinLength(2)

                .General.FirstName.Type("b")
                .General.LastName.Click()
                .ValidationMessages[x => x.General.FirstName].Should.Not.BeVisible()
                .General.LastName.Type("y")
                .General.FirstName.Click()
                .ValidationMessages[x => x.General.LastName].Should.Not.BeVisible()
                .ValidationMessages.Should.BeEmpty()

                .General.Email.SetRandom()
                .General.Office.Set(Office.Rome)
                .General.Gender.Set(Gender.Female)
                .Save();
}
