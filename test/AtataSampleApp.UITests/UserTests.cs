using System;
using Atata;
using NUnit.Framework;

namespace AtataSampleApp.UITests
{
    public class UserTests : UITestFixture
    {
        [Test]
        public void Create()
        {
            Login()
                .New()
                    .ModalTitle.Should.Equal("New User")
                    .General.FirstName.SetRandom(out string firstName)
                    .General.LastName.SetRandom(out string lastName)
                    .General.Email.SetRandom(out string email)
                    .General.Office.SetRandom(out Office office)
                    .General.Gender.SetRandom(out Gender gender)
                    .Save()
                .GetUserRow(email).View()
                    .AggregateAssert(x => x
                        .Header.Should.Equal($"{firstName} {lastName}")
                        .Email.Should.Equal(email)
                        .Office.Should.Equal(office)
                        .Gender.Should.Equal(gender)
                        .Birthday.Should.Not.Exist()
                        .Notes.Should.Not.Exist());
        }

        [Test]
        public void Create_OneAndThenCancelSecond()
        {
            Login()
                .Users.Rows.Count.Get(out int userCount) // Store initial count of users.
                .New()
                    .Do(SetRequiredFieldsWithRandomValues)
                    .Save()
                .Users.Rows.Count.Should.Equal(++userCount) // Verify that count is incremented.
                .New()
                    .Do(SetRequiredFieldsWithRandomValues)
                    .Cancel()
                .Users.Rows.Count.Should.Equal(userCount); // Verify that count is not changed.
        }

        private UserEditWindow SetRequiredFieldsWithRandomValues(UserEditWindow window)
        {
            return window
                .General.FirstName.SetRandom()
                .General.LastName.SetRandom()
                .General.Email.SetRandom()
                .General.Office.SetRandom()
                .General.Gender.SetRandom();
        }

        [Test]
        public void Edit()
        {
            Office office = Office.NewYork;
            Gender gender = Gender.Male;

            var editWindow = Login()
                .New()
                    .General.FirstName.SetRandom(out string firstName)
                    .General.LastName.SetRandom(out string lastName)
                    .General.Email.SetRandom(out string email)
                    .General.Office.Set(office)
                    .General.Gender.Set(gender)
                    .Save()
                .Users.Rows[x => x.Email == email && x.Office == office].Edit();

            office = Office.Tokio;
            gender = Gender.Female;
            DateTime birthday = new DateTime(1980, 4, 4);
            string notes = "Some notes";

            editWindow
                    .ModalTitle.Should.Equal($"{firstName} {lastName}")
                    .General.Email.Should.BeReadOnly()
                    .General.Office.Set(office)
                    .General.Gender.Set(gender)
                    .Additional.Birthday.Set(birthday)
                    .Additional.Notes.Set(notes)
                    .Save()
                .Users.Rows[x => x.Email == email && x.Office == office].View()
                    .AggregateAssert(x => x
                        .PageTitle.Should.StartWith($"{firstName} {lastName}")
                        .Header.Should.Equal($"{firstName} {lastName}")
                        .Email.Should.Equal(email)
                        .Office.Should.Equal(office)
                        .Gender.Should.Equal(gender)
                        .Birthday.Should.Equal(birthday)
                        .Notes.Should.Equal(notes));
        }

        [Test]
        public void Delete()
        {
            Login()
                .New()
                    .General.FirstName.SetRandom()
                    .General.LastName.SetRandom()
                    .General.Email.SetRandom(out string email)
                    .General.Office.SetRandom()
                    .General.Gender.SetRandom()
                    .Save()
                .GetUserRow(email).Delete()
                .GetUserRow(email).Should.Not.Exist();
        }

        [Test]
        public void Create_Validation_Required()
        {
            Login()
                .New()
                    .Save.Click()
                    .AggregateAssert(x => x
                        .ValidationMessages[x => x.General.FirstName].Should.BeRequired()
                        .ValidationMessages[x => x.General.LastName].Should.BeRequired()
                        .ValidationMessages[x => x.General.Email].Should.BeRequired()
                        .ValidationMessages[x => x.General.Office].Should.BeRequired()
                        .ValidationMessages[x => x.General.Gender].Should.BeRequired()
                        .ValidationMessages.Should.HaveCount(5));
        }

        [Test]
        public void Create_Validation_MinLength()
        {
            Login()
                .New()
                    .General.FirstName.Set("a")
                    .General.LastName.Set("a")
                    .Save.Click()
                    .AggregateAssert(x => x
                        .ValidationMessages[x => x.General.FirstName].Should.HaveMinLength(2)
                        .ValidationMessages[x => x.General.LastName].Should.HaveMinLength(2));
        }

        [Test]
        public void Create_Validation_RealTime()
        {
            Login()
                .New()
                    .ValidationMessages.Should.BeEmpty()

                    .General.FirstName.Focus()
                    .General.LastName.Focus()
                    .ValidationMessages.Should.HaveCount(1)
                    .ValidationMessages[x => x.General.FirstName].Should.BeRequired()
                    .General.FirstName.Set("a")
                    .General.LastName.Set("a")
                    .General.FirstName.Focus()
                    .ValidationMessages.Should.HaveCount(2)
                    .ValidationMessages[x => x.General.FirstName].Should.HaveMinLength(2)
                    .ValidationMessages[x => x.General.LastName].Should.HaveMinLength(2)

                    .General.FirstName.Type("b")
                    .General.LastName.Focus()
                    .ValidationMessages[x => x.General.FirstName].Should.Not.Exist()
                    .General.LastName.Type("b")
                    .General.FirstName.Focus()
                    .ValidationMessages[x => x.General.LastName].Should.Not.Exist()
                    .ValidationMessages.Should.BeEmpty()

                    .General.Email.SetRandom()
                    .General.Office.Set(Office.Rome)
                    .General.Gender.Set(Gender.Female)
                    .Save();
        }

        [Test]
        public void User_Settings()
        {
            Login()
                .Menu.Account.Settings();
        }
    }
}
