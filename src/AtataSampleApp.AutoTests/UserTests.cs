using System;
using Atata;
using NUnit.Framework;

namespace AtataSampleApp.AutoTests
{
    public class UserTests : UITestFixture
    {
        [Test]
        public void User_Create()
        {
            string firstName, lastName, email;
            Office office = Office.NewYork;
            Gender gender = Gender.Male;

            Login().
                New().
                    ModalTitle.Should.Equal("New User").
                    General.FirstName.SetRandom(out firstName).
                    General.LastName.SetRandom(out lastName).
                    General.Email.SetRandom(out email).
                    General.Office.Set(office).
                    General.Gender.Set(gender).
                    Save().
                Users.Rows[x => x.FirstName == firstName && x.LastName == lastName && x.Email == email && x.Office == office].View().
                    Header.Should.Equal($"{firstName} {lastName}").
                    Email.Should.Equal(email).
                    Office.Should.Equal(office).
                    Gender.Should.Equal(gender).
                    Birthday.Should.Not.Exist().
                    Notes.Should.Not.Exist();
        }

        [Test]
        public void User_Edit()
        {
            string firstName, lastName, email, notes;
            Office office = Office.NewYork;
            Gender gender = Gender.Male;
            DateTime birthday = new DateTime(1980, 4, 4);

            Login().
                New().
                    General.FirstName.SetRandom(out firstName).
                    General.LastName.SetRandom(out lastName).
                    General.Email.SetRandom(out email).
                    General.Office.Set(office).
                    General.Gender.Set(gender).
                    Save().
                Users.Rows[x => x.FirstName == firstName && x.LastName == lastName && x.Email == email && x.Office == office].Edit().
                    ModalTitle.Should.Equal($"{firstName} {lastName}").
                    General.Email.Should.BeReadOnly().
                    General.Office.Set(office = Office.Tokio).
                    General.Gender.Set(gender = Gender.Female).
                    Additional.Birthday.Set(birthday).
                    Additional.Notes.SetRandom(out notes).
                    Save().
                Users.Rows[x => x.FirstName == firstName && x.LastName == lastName && x.Email == email && x.Office == office].View().
                    PageTitle.Should.StartWith($"{firstName} {lastName}").
                    Header.Should.Equal($"{firstName} {lastName}").
                    Email.Should.Equal(email).
                    Office.Should.Equal(office).
                    Gender.Should.Equal(gender).
                    Birthday.Should.Equal(birthday).
                    Notes.Should.Equal(notes);
        }

        [Test]
        public void User_Delete()
        {
            string firstName, lastName, email;
            Office office = Office.NewYork;
            Gender gender = Gender.Male;

            Login().
                New().
                    General.FirstName.SetRandom(out firstName).
                    General.LastName.SetRandom(out lastName).
                    General.Email.SetRandom(out email).
                    General.Office.Set(office).
                    General.Gender.Set(gender).
                    Save().
                Users.Rows[x => x.FirstName == firstName && x.LastName == lastName && x.Email == email && x.Office == office].Delete().
                Users.Rows[x => x.FirstName == firstName && x.LastName == lastName && x.Email == email && x.Office == office].Should.Not.Exist();
        }

        [Test]
        public void User_Validation_Required()
        {
            Login().
                New().
                    Save.Click().
                    ValidationMessages[x => x.General.FirstName].Should.BeRequired().
                    ValidationMessages[x => x.General.LastName].Should.BeRequired().
                    ValidationMessages[x => x.General.Email].Should.BeRequired().
                    ValidationMessages[x => x.General.Office].Should.BeRequired().
                    ValidationMessages[x => x.General.Gender].Should.BeRequired().
                    ValidationMessages.Should.HaveCount(5);
        }

        [Test]
        public void User_Validation_MinLength()
        {
            Login().
                New().
                    General.FirstName.Set("a").
                    General.LastName.Set("a").
                    Save.Click().
                    ValidationMessages[x => x.General.FirstName].Should.HaveMinLength(2).
                    ValidationMessages[x => x.General.LastName].Should.HaveMinLength(2);
        }

        [Test]
        public void User_Validation_RealTime()
        {
            Login().
                New().
                    ValidationMessages.Should.BeEmpty().

                    General.FirstName.Focus().
                    General.LastName.Focus().
                    ValidationMessages.Should.HaveCount(1).
                    ValidationMessages[x => x.General.FirstName].Should.BeRequired().
                    General.FirstName.Set("a").
                    General.LastName.Set("a").
                    General.FirstName.Focus().
                    ValidationMessages.Should.HaveCount(2).
                    ValidationMessages[x => x.General.FirstName].Should.HaveMinLength(2).
                    ValidationMessages[x => x.General.LastName].Should.HaveMinLength(2).

                    General.FirstName.Append("b").
                    General.LastName.Focus().
                    ValidationMessages[x => x.General.FirstName].Should.Not.Exist().
                    General.LastName.Append("b").
                    General.FirstName.Focus().
                    ValidationMessages[x => x.General.LastName].Should.Not.Exist().
                    ValidationMessages.Should.BeEmpty().

                    General.Email.SetRandom().
                    General.Office.Set(Office.Rome).
                    General.Gender.Set(Gender.Female).
                    Save();
        }

        [Test]
        public void User_Settings()
        {
            Login().
                Menu.Account.Settings();
        }
    }
}
