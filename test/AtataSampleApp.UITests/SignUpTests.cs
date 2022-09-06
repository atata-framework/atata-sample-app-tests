using Atata;
using NUnit.Framework;

namespace AtataSampleApp.UITests
{
    public class SignUpTests : UITestFixture
    {
        [Test]
        public void SignUp() =>
            Go.To<SignUpPage>()
                .FirstName.SetRandom(out string firstName)
                .LastName.SetRandom(out string lastName)
                .Email.SetRandom(out string email)
                .Password.SetRandom()
                .Agreement.Check()
                .SignUp()
                    .AggregateAssert(x => x
                        .Menu.Account.SignOut.Should().Exist()
                        .Header.Should.Be($"{firstName} {lastName}")
                        .Email.Should.Be(email)
                        .Office.Should.Not.Exist()
                        .Gender.Should.Not.Exist()
                        .Birthday.Should.Not.Exist()
                        .Notes.Should.Not.Exist());

        [Test]
        public void Validation_Required() =>
            Go.To<SignUpPage>()
                .SignUp.Click()
                .ValidationMessages[x => x.FirstName].Should.BeRequired()
                .ValidationMessages[x => x.LastName].Should.BeRequired()
                .ValidationMessages[x => x.Email].Should.BeRequired()
                .ValidationMessages[x => x.Password].Should.BeRequired()
                .ValidationMessages[x => x.Agreement].Should.BeRequired()
                .ValidationMessages.Should.HaveCount(5);

        [Test]
        public void Validation_MinLength() =>
            Go.To<SignUpPage>()
                .FirstName.Set("a")
                .LastName.Set("a")
                .Password.Set("a")
                .SignUp.Click()
                .ValidationMessages[x => x.FirstName].Should.HaveMinLength(2)
                .ValidationMessages[x => x.LastName].Should.HaveMinLength(2)
                .ValidationMessages[x => x.Password].Should.HaveMinLength(6);

        [Test]
        public void Validation_IncorrectEmail() =>
            Go.To<SignUpPage>()
                .Email.Set("some@email")
                .SignUp.Click()
                .ValidationMessages[x => x.Email].Should.HaveIncorrectFormat()
                .Email.Type(".com")
                .SignUp.Click()
                .ValidationMessages[x => x.Email].Should.Not.Exist();

        [Test]
        public void Validation_UniqueEmail() =>
            Go.To<SignUpPage>()
                .FirstName.SetRandom()
                .LastName.SetRandom()
                .Email.SetRandom(out string email)
                .Password.SetRandom()
                .Agreement.Check()
                .SignUp()
                    .Menu.Account.SignOut()
                        .Menu.SignUp()
                            .Email.Set(email)
                            .SignUp.Click()
                            .ValidationMessages[x => x.Email].Should.Be("is already used by another user");
    }
}
