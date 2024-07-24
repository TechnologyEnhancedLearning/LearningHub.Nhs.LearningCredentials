-- Populate the Period Unit table with initial values

IF NOT EXISTS (SELECT 1 FROM [dsp].[PeriodUnit] WHERE Id = 1)
BEGIN
	INSERT INTO [dsp].[PeriodUnit] ([Id],[Name],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
	VALUES (1, 'Minute', 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END


IF NOT EXISTS (SELECT 1 FROM [dsp].[PeriodUnit] WHERE Id = 2)
BEGIN
	INSERT INTO [dsp].[PeriodUnit] ([Id],[Name],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
	VALUES (2, 'Hour', 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END

IF NOT EXISTS (SELECT 1 FROM [dsp].[PeriodUnit] WHERE Id = 3)
BEGIN
	INSERT INTO [dsp].[PeriodUnit] ([Id],[Name],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
	VALUES (3, 'Day', 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END

IF NOT EXISTS (SELECT 1 FROM [dsp].[PeriodUnit] WHERE Id = 4)
BEGIN
	INSERT INTO [dsp].[PeriodUnit] ([Id],[Name],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
	VALUES (4, 'Week', 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END

IF NOT EXISTS (SELECT 1 FROM [dsp].[PeriodUnit] WHERE Id = 5)
BEGIN
	INSERT INTO [dsp].[PeriodUnit] ([Id],[Name],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
	VALUES (5, 'Month', 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END

IF NOT EXISTS (SELECT 1 FROM [dsp].[PeriodUnit] WHERE Id = 6)
BEGIN
	INSERT INTO [dsp].[PeriodUnit] ([Id],[Name],[Deleted],[CreateUserId],[CreateDate],[AmendUserId],[AmendDate])
	VALUES (6, 'Year', 0, 4, SYSDATETIMEOFFSET(), 4, SYSDATETIMEOFFSET())
END
GO
