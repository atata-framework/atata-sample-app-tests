# Atata Sample App Tests

[![Build status](https://dev.azure.com/atata-framework/atata-sample-app-tests/_apis/build/status/atata-sample-app-tests-ci)](https://dev.azure.com/atata-framework/atata-sample-app-tests/_build/latest?definitionId=26)
[![Atata docs](https://img.shields.io/badge/docs-Atata_Framework-orange.svg)](https://atata.io)
[![Gitter](https://badges.gitter.im/atata-framework/atata.svg)](https://gitter.im/atata-framework/atata)
[![Slack](https://img.shields.io/badge/join-Slack-green.svg?colorB=4EB898)](https://join.slack.com/t/atata-framework/shared_invite/zt-5j3lyln7-WD1ZtMDzXBhPm0yXLDBzbA)
[![Twitter](https://img.shields.io/badge/follow-@AtataFramework-blue.svg)](https://twitter.com/AtataFramework)

Automated UI tests C#/.NET application based on [Atata Framework](https://github.com/atata-framework/atata).
It uses [Atata Sample App](https://demo.atata.io) ([repository](https://github.com/atata-framework/atata-sample-app)) as a testing website and NUnit 3 as a test engine.
Tests application demonstrates different testing approaches and features of Atata Framework.

## Features

- Atata configuration and settings set-up.
- Page navigation.
- Controls finding.
- Data input and verification.
- Validation messages verification.
- Usage of triggers.
- Interaction with pop-ups (Bootstrap modal) and alerts.
- Work with tables.
- Logging, screenshots and snapshots.
- Page HTML validation.

## Sample Test

```cs
public sealed class UserTests : UITestFixture
{
    [Test]
    public void Create() =>
        Login()
            .New()
                .ModalTitle.Should.Be("New User")
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

    //...
}
```

## License

Atata is an open source software, licensed under the Apache License 2.0. See [LICENSE](LICENSE) for details.
