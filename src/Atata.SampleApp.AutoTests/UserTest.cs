using NUnit.Framework;

namespace Atata.SampleApp.AutoTests
{
    [TestFixture]
    public class UserTest : AutoTest
    {
        [Test]
        public void User_Create()
        {
            Login().
                New().
                    FirstName.SetRandom().
                    LastName.SetRandom().
                    Email.SetRandom().
                    Office.Set(Office.NewYork).
                    Sex.Set(Sex.Male).
                    Save();
        }
    }
}
