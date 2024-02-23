-- Populate the UserVerifiableCredentialStatus table with initial values

IF NOT EXISTS (SELECT * FROM [dsp].[UserVerifiableCredentialStatus] WHERE [Id] = 1)
BEGIN
	INSERT INTO [dsp].[UserVerifiableCredentialStatus] (Id, StatusName, Deleted, CreateUserId, CreateDate, AmendUserId, AmendDate)
	Values (1, 'Created', 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END

IF NOT EXISTS (SELECT * FROM [dsp].[UserVerifiableCredentialStatus] WHERE [Id] = 2)
BEGIN
	INSERT INTO [dsp].[UserVerifiableCredentialStatus] (Id, StatusName, Deleted, CreateUserId, CreateDate, AmendUserId, AmendDate)
	Values (2, 'Revoked', 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END

GO
