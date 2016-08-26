namespace Atata.SampleApp.AutoTests
{
    public static class IDataVerificationProviderExtensions
    {
        public static TOwner BeRequired<TOwner>(this IFieldVerificationProvider<string, ValidationMessage<TOwner>, TOwner> should)
            where TOwner : PageObject<TOwner>
        {
            return should.Equal("is required");
        }

        public static TOwner BeInvalid<TOwner>(this IFieldVerificationProvider<string, ValidationMessage<TOwner>, TOwner> should)
            where TOwner : PageObject<TOwner>
        {
            return should.Contain("invalid");
        }
    }
}
