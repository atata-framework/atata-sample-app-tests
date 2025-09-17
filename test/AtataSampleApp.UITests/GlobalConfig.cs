namespace AtataSampleApp.UITests;

public sealed class GlobalConfig
{
    public required string BaseUrl { get; init; }

    public required AccountConfiguration Account { get; init; }

    public sealed class AccountConfiguration
    {
        public required string Email { get; init; }

        public required string Password { get; init; }
    }
}
