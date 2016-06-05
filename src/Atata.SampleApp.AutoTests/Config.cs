using System.Configuration;

namespace Atata.SampleApp.AutoTests
{
    public static class Config
    {
        static Config()
        {
            Url = ConfigurationManager.AppSettings["Url"];
        }

        public static string Url { get; private set; }

        public static class Account
        {
            static Account()
            {
                Email = ConfigurationManager.AppSettings["Email"];
                Password = ConfigurationManager.AppSettings["Password"];
            }

            public static string Email { get; private set; }
            public static string Password { get; private set; }
        }
    }
}
