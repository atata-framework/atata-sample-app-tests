using System.Configuration;

namespace Atata.SampleApp.AutoTests
{
    public static class Config
    {
        public static string Url { get; } = ConfigurationManager.AppSettings["Url"];

        public static class Account
        {
            public static string Email { get; } = ConfigurationManager.AppSettings["Email"];
            public static string Password { get; } = ConfigurationManager.AppSettings["Password"];
        }
    }
}
