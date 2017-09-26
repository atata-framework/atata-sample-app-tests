using Atata;

[assembly: Culture("en-us")]
[assembly: VerifyTitleSettings(Format = "{0} - Atata Sample App")]
[assembly: Screenshot(On = TriggerEvents.BeforeClick, AppliesTo = TriggerScope.Children)]
