namespace AtataSampleApp.UITests;

/// <summary>
/// Represents configuration that is read from "Atata.json".
/// The name of class doesn't matter, it can be: "Config", "AppConfig", etc.
/// </summary>
public sealed class AtataConfig : JsonConfig<AtataConfig>
{
    public AccountConfiguration Account { get; init; } = null!;

    public sealed class AccountConfiguration
    {
        public required string Email { get; init; }

        public required string Password { get; init; }
    }
}
