﻿namespace AtataSampleApp.UITests;

[ControlDefinition("div[contains(concat(' ', normalize-space(@class), ' '), ' has-error ')]//span[contains(concat(' ', normalize-space(@class), ' '), ' help-block ')]")]
public sealed class ValidationMessage<TOwner> : Text<TOwner>
    where TOwner : PageObject<TOwner>
{
    public new FieldVerificationProvider<string, ValidationMessage<TOwner>, TOwner> Should =>
        new(this);
}
