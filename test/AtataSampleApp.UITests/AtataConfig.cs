using Atata.Configuration.Json;

namespace AtataSampleApp.UITests;

/// <summary>
/// Represents configuration that is read from "Atata.json".
/// The name of class doesn't matter, it can be: "Config", "AppConfig", etc.
/// </summary>
public class AtataConfig : JsonConfig<AtataConfig>
{
    public AccountConfiguration Account { get; set; }

    public class AccountConfiguration
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
