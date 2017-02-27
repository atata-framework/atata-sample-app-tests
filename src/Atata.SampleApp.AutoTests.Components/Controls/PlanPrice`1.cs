using System;

namespace Atata.SampleApp.AutoTests
{
    public class PlanPrice<TOwner> : Currency<TOwner>
        where TOwner : PageObject<TOwner>
    {
        protected override decimal? ConvertStringToValue(string value)
        {
            if (value.Equals("free", StringComparison.InvariantCultureIgnoreCase))
                return 0;

            return base.ConvertStringToValue(value);
        }
    }
}
