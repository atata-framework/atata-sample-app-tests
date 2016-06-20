using System;
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
                    General.FirstName.SetRandom(out firstName).
                    General.LastName.SetRandom(out lastName).
                    General.Email.SetRandom(out email).
                    General.Office.Set(office).
                    General.Sex.Set(sex).
                    Save().
                Users.Row(x => x.FirstName == firstName && x.LastName == lastName && x.Email == email && x.Office == office).View().
                    Header.VerifyEquals(firstName + " " + lastName).
                    Email.VerifyEquals(email).
                    Office.VerifyEquals(office).
                    Sex.VerifyEquals(sex).
                    Birthday.VerifyMissing().
                    Notes.VerifyMissing();
        }

        [Test]
        public void User_Edit()
        {
            string firstName, lastName, email, notes;
            Office office = Office.NewYork;
            Sex sex = Sex.Male;
            DateTime birthday = new DateTime(1980, 4, 4);

            Login().
                New().
                    General.FirstName.SetRandom(out firstName).
                    General.LastName.SetRandom(out lastName).
                    General.Email.SetRandom(out email).
                    General.Office.Set(office).
                    General.Sex.Set(sex).
                    Save().
                Users.Row(x => x.FirstName == firstName && x.LastName == lastName && x.Email == email && x.Office == office).Edit().
                    General.Office.Set(office = Office.Tokio).
                    General.Sex.Set(sex = Sex.Female).
                    Additional.Birthday.Set(birthday).
                    Additional.Notes.SetRandom(out notes).
                    Save().
                Users.Row(x => x.FirstName == firstName && x.LastName == lastName && x.Email == email && x.Office == office).View().
                    Header.VerifyEquals(firstName + " " + lastName).
                    Email.VerifyEquals(email).
                    Office.VerifyEquals(office).
                    Sex.VerifyEquals(sex).
                    Birthday.VerifyEquals(birthday).
                    Notes.VerifyEquals(notes);
        }

        [Test]
        public void User_Delete()
        {
            string firstName, lastName, email;
            Office office = Office.NewYork;
            Sex sex = Sex.Male;

            Login().
                New().
                    General.FirstName.SetRandom(out firstName).
                    General.LastName.SetRandom(out lastName).
                    General.Email.SetRandom(out email).
                    General.Office.Set(office).
                    General.Sex.Set(sex).
                    Save().
                Users.Row(x => x.FirstName == firstName && x.LastName == lastName && x.Email == email && x.Office == office).Delete().
                Users.Row(x => x.FirstName == firstName && x.LastName == lastName && x.Email == email && x.Office == office).VerifyMissing();
        }
    }
}
