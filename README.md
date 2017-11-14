# Atata Sample App Tests

[![Docs](https://img.shields.io/badge/docs-Atata_Framework-orange.svg)](https://atata-framework.github.io/)
[![Twitter](https://img.shields.io/badge/follow-@AtataFramework-blue.svg)](https://twitter.com/AtataFramework)

Automated UI tests C#/.NET application based on [Atata Framework](https://github.com/atata-framework/atata).
It uses [Atata Sample App](https://atata-framework.github.io/atata-sample-app/#!/) ([repository](https://github.com/atata-framework/atata-sample-app)) as a testing website and NUnit 3 as a test engine.
Tests application demonstates different testing approaches and features of the Atata framework.

## Features

* Atata configuation and settings set-up
* Page navigation
* Controls finding
* Data input and verification
* Validation messages verification
* Usage of triggers
* Interaction with pop-ups (Bootstrap modal) and alerts
* Work with tables
* Logging

## Sample Test

```cs
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
```

## License

Atata is an open source software, licensed under the Apache License 2.0. See [LICENSE](LICENSE) for details.