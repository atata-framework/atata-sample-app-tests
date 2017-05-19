using System.Configuration;

namespace AtataSampleApp.AutoTests
{
    public static class Config
    {
        public static string Url { get; } = ConfigurationManager.AppSettings[nameof(Url)];

        public static class Account
        {
            public static string Email { get; } = ConfigurationManager.AppSettings[nameof(Email)];

            public static string Password { get; } = ConfigurationManager.AppSettings[nameof(Password)];
        }
    }
}
