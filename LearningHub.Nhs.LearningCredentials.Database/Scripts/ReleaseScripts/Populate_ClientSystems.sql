-- Populate the Client System table with initial values

IF NOT EXISTS (SELECT 1 FROM [system].[ClientSystem] WHERE Id = 1)
BEGIN
	INSERT INTO [system].[ClientSystem] ([Id],[Name],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
	VALUES (1, 'elearning for healthcare', 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END
IF NOT EXISTS (SELECT 1 FROM [system].[ClientSystem] WHERE Id = 2)
BEGIN
	INSERT INTO [system].[ClientSystem] ([Id],[Name],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
	VALUES (2, 'Learning Hub', 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END
GO
IF NOT EXISTS (SELECT 1 FROM [system].[ClientSystem] WHERE Id = 3)
BEGIN
	INSERT INTO [system].[ClientSystem] ([Id],[Name],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
	VALUES (3, 'Digital Learning Solutions', 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END
GO
