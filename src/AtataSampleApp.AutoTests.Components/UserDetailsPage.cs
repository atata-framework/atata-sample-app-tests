﻿using System;
using Atata;
using _ = AtataSampleApp.AutoTests.UserDetailsPage;

namespace AtataSampleApp.AutoTests
{
    public class UserDetailsPage : AppPage<_>
    {
        [FindFirst]
        public H1<_> Header { get; private set; }

        [FindByDescriptionTerm]
        public Text<_> Email { get; private set; }

        [FindByDescriptionTerm]
        public Content<Office, _> Office { get; private set; }

        [FindByDescriptionTerm]
        public Content<Gender, _> Gender { get; private set; }

        [FindByDescriptionTerm]
        public Content<DateTime?, _> Birthday { get; private set; }

        [FindByDescriptionTerm]
        public Text<_> Notes { get; private set; }
    }
}
