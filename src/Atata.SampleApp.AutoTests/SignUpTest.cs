using NUnit.Framework;

namespace Atata.SampleApp.AutoTests
{
    public class SignUpTest : AutoTest
    {
        [Test]
        public void SignUp()
        {
            string firstName, lastName, email;
            Office office = Office.Rome;
            Gender gender = Gender.Female;

            Go.To<SignUpPage>().
                FirstName.SetRandom(out firstName).
                LastName.SetRandom(out lastName).
                Email.SetRandom(out email).
                Password.SetRandom().
                Office.Set(office).
                Gender.Set(gender).
                Agreement.Check().
                SignUp().
                    Menu.Account.SignOut.Should().Exist().
                    Header.Should.Equal($"{firstName} {lastName}").
                    Email.Should.Equal(email).
                    Office.Should.Equal(office).
                    Gender.Should.Equal(gender).
                    Birthday.Should.Not.Exist().
                    Notes.Should.Not.Exist();
        }

        [Test]
        public void SignUp_Validation_Required()
        {
            Go.To<SignUpPage>().
                SignUp.Click().
                ValidationMessages[x => x.FirstName].Should.BeRequired().
                ValidationMessages[x => x.LastName].Should.BeRequired().
                ValidationMessages[x => x.Email].Should.BeRequired().
                ValidationMessages[x => x.Password].Should.BeRequired().
                ValidationMessages[x => x.Office].Should.BeRequired().
                ValidationMessages[x => x.Gender].Should.BeRequired().
                ValidationMessages[x => x.Agreement].Should.BeRequired().
                ValidationMessages.Should.HaveCount(7);
        }

        [Test]
        public void SignUp_Validation_MinLength()
        {
            Go.To<SignUpPage>().
                FirstName.Set("a").
                LastName.Set("a").
                Password.Set("a").
                SignUp.Click().
                ValidationMessages[x => x.FirstName].Should.HaveMinLength(2).
                ValidationMessages[x => x.LastName].Should.HaveMinLength(2).
                ValidationMessages[x => x.Password].Should.HaveMinLength(6);
        }

        [Test]
        public void SignUp_Validation_IncorrectEmail()
        {
            Go.To<SignUpPage>().
                Email.Set("some@email").
                SignUp.Click().
                ValidationMessages[x => x.Email].Should.HaveIncorrectFormat().
                Email.Append(".com").
                SignUp.Click().
                ValidationMessages[x => x.Email].Should.Not.Exist();
        }

        [Test]
        public void SignUp_Validation_UniqueEmail()
        {
            string email;
            Office office = Office.Washington;
            Gender gender = Gender.Male;

            Go.To<SignUpPage>().
                FirstName.SetRandom().
                LastName.SetRandom().
                Email.SetRandom(out email).
                Password.SetRandom().
                Office.Set(office).
                Gender.Set(gender).
                Agreement.Check().
                SignUp().
                    Menu.Account.SignOut().
                        Menu.SignUp().
                            Email.Set(email).
                            SignUp.Click().
                            ValidationMessages[x => x.Email].Should.Equal("is already used by another user");
        }
    }
}
