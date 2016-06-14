using System;
using _ = Atata.SampleApp.AutoTests.UserDetailsPage;

namespace Atata.SampleApp.AutoTests
{
    public class UserDetailsPage : Page<_>
    {
        public UserDetailsPage(string userName = null)
        {
        }

        [FindByDescriptionTerm]
        public Text<_> Email { get; private set; }

        [FindByDescriptionTerm]
        public Text<_> Office { get; private set; }

        [FindByDescriptionTerm]
        public Content<Sex, _> Sex { get; private set; }

        [FindByDescriptionTerm]
        public Content<DateTime?, _> Birthday { get; private set; }

        [FindByDescriptionTerm]
        public Text<_> Notes { get; private set; }
    }
}
