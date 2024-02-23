-- Populate the Verifiable Credential table with initial values

IF NOT EXISTS (SELECT * FROM [dsp].[VerifiableCredential] WHERE [ClientSystemId] = 1 AND [ClientSystemCredentialId] = 37861)
BEGIN
	INSERT INTO [dsp].[VerifiableCredential]
			   ([CredentialName],[ClientSystemId],[ClientSystemCredentialId],[ScopeName],[ClaimPrefix],[PeriodUnit],[PeriodQty],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
		 VALUES ('Conflict resolution', 1, 37861,'issue.TestCredential','CR-', 6, 1, 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END

IF NOT EXISTS (SELECT * FROM [dsp].[VerifiableCredential] WHERE [ClientSystemId] = 1 AND [ClientSystemCredentialId] = 33902)
BEGIN
	INSERT INTO [dsp].[VerifiableCredential]
			   ([CredentialName],[ClientSystemId],[ClientSystemCredentialId],[ScopeName],[ClaimPrefix],[PeriodUnit],[PeriodQty],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
		 VALUES ('Equality, Diversity and Human Rights', 1, 33902,'issue.TestCredential','ED-', 6, 1, 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END

IF NOT EXISTS (SELECT * FROM [dsp].[VerifiableCredential] WHERE [ClientSystemId] = 1 AND [ClientSystemCredentialId] = 37856)
BEGIN
	INSERT INTO [dsp].[VerifiableCredential]
			   ([CredentialName],[ClientSystemId],[ClientSystemCredentialId],[ScopeName],[ClaimPrefix],[PeriodUnit],[PeriodQty],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
		 VALUES ('Fire safety', 1, 37856,'issue.TestCredential','FS-', 6, 1, 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END


IF NOT EXISTS (SELECT * FROM [dsp].[VerifiableCredential] WHERE [ClientSystemId] = 1 AND [ClientSystemCredentialId] = 37864)
BEGIN
	INSERT INTO [dsp].[VerifiableCredential]
			   ([CredentialName],[ClientSystemId],[ClientSystemCredentialId],[ScopeName],[ClaimPrefix],[PeriodUnit],[PeriodQty],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
		 VALUES ('Health, Safety and Welfare', 1, 37864,'issue.TestCredential','HS-', 6, 1, 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END

IF NOT EXISTS (SELECT * FROM [dsp].[VerifiableCredential] WHERE [ClientSystemId] = 1 AND [ClientSystemCredentialId] = 37862)
BEGIN
	INSERT INTO [dsp].[VerifiableCredential]
			   ([CredentialName],[ClientSystemId],[ClientSystemCredentialId],[ScopeName],[ClaimPrefix],[PeriodUnit],[PeriodQty],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
		 VALUES ('Infection Prevention and Control', 1, 37862,'issue.TestCredential','ID-', 6, 1, 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END

IF NOT EXISTS (SELECT * FROM [dsp].[VerifiableCredential] WHERE [ClientSystemId] = 1 AND [ClientSystemCredentialId] = 38993)
BEGIN
	INSERT INTO [dsp].[VerifiableCredential]
			   ([CredentialName],[ClientSystemId],[ClientSystemCredentialId],[ScopeName],[ClaimPrefix],[PeriodUnit],[PeriodQty],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
		 VALUES ('Information Governance & Data Security', 1, 38993,'issue.TestCredential','IG-', 6, 1, 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END

IF NOT EXISTS (SELECT * FROM [dsp].[VerifiableCredential] WHERE [ClientSystemId] = 1 AND [ClientSystemCredentialId] = 37860)
BEGIN
	INSERT INTO [dsp].[VerifiableCredential]
			   ([CredentialName],[ClientSystemId],[ClientSystemCredentialId],[ScopeName],[ClaimPrefix],[PeriodUnit],[PeriodQty],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
		 VALUES ('Moving and Handling', 1, 37860,'issue.TestCredential','MH-', 6, 1, 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END

IF NOT EXISTS (SELECT * FROM [dsp].[VerifiableCredential] WHERE [ClientSystemId] = 1 AND [ClientSystemCredentialId] = 37858)
BEGIN
	INSERT INTO [dsp].[VerifiableCredential]
			   ([CredentialName],[ClientSystemId],[ClientSystemCredentialId],[ScopeName],[ClaimPrefix],[PeriodUnit],[PeriodQty],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
		 VALUES ('Preventing Radicalisation', 1, 37858,'issue.TestCredential','PR-', 6, 1, 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END

IF NOT EXISTS (SELECT * FROM [dsp].[VerifiableCredential] WHERE [ClientSystemId] = 1 AND [ClientSystemCredentialId] = 37863)
BEGIN
	INSERT INTO [dsp].[VerifiableCredential]
			   ([CredentialName],[ClientSystemId],[ClientSystemCredentialId],[ScopeName],[ClaimPrefix],[PeriodUnit],[PeriodQty],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
		 VALUES ('Resuscitation', 1, 37863,'issue.TestCredential','RE-', 6, 1, 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END

IF NOT EXISTS (SELECT * FROM [dsp].[VerifiableCredential] WHERE [ClientSystemId] = 1 AND [ClientSystemCredentialId] = 37872)
BEGIN
	INSERT INTO [dsp].[VerifiableCredential]
			   ([CredentialName],[ClientSystemId],[ClientSystemCredentialId],[ScopeName],[ClaimPrefix],[PeriodUnit],[PeriodQty],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
		 VALUES ('Safeguarding Adults', 1, 37872,'issue.TestCredential','SA-', 6, 1, 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END

IF NOT EXISTS (SELECT * FROM [dsp].[VerifiableCredential] WHERE [ClientSystemId] = 1 AND [ClientSystemCredentialId] = 37873)
BEGIN
	INSERT INTO [dsp].[VerifiableCredential]
			   ([CredentialName],[ClientSystemId],[ClientSystemCredentialId],[ScopeName],[ClaimPrefix],[PeriodUnit],[PeriodQty],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
		 VALUES ('Safeguarding Children', 1, 37873,'issue.TestCredential','SC-', 6, 1, 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END

GO
