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
    }
}
