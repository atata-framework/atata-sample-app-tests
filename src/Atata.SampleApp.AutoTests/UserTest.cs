using NUnit.Framework;

namespace Atata.SampleApp.AutoTests
{
    [TestFixture]
    public class UserTest : AutoTest
    {
        [Test]
        public void User_Create()
        {
            string firstName, lastName, email;
            Office office = Office.NewYork;
            Sex sex = Sex.Male;

            Login().
                New().
                    FirstName.SetRandom(out firstName).
                    LastName.SetRandom(out lastName).
                    Email.SetRandom(out email).
                    Office.Set(office).
                    Sex.Set(sex).
                    Save().
                Users.Row(x => x.FirstName == firstName && x.LastName == lastName && x.Email == email && x.Office == office).View().
                    Header.VerifyEquals(firstName + " " + lastName).
                    Email.VerifyEquals(email).
                    Office.VerifyEquals(office).
                    Sex.VerifyEquals(sex).
                    Birthday.VerifyMissing().
                    Notes.VerifyMissing();
        }
    }
}
