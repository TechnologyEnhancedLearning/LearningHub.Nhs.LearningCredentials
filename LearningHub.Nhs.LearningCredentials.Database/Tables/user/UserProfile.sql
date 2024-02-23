CREATE TABLE [user].[UserProfile] (
    [Id]               INT                                         NOT NULL,
    [UserName]         NVARCHAR (50)                               NOT NULL,
    [Deleted]          BIT                                         NOT NULL,
    [CreateUserId]     INT                                         NOT NULL,
    [CreateDate]       DATETIMEOFFSET (7)                          NOT NULL,
    [AmendUserId]      INT                                         NOT NULL,
    [AmendDate]        DATETIMEOFFSET (7)                          NOT NULL,
    [VersionStartTime] DATETIME2 (7) GENERATED ALWAYS AS ROW START DEFAULT (getutcdate()) NOT NULL,
    [VersionEndTime]   DATETIME2 (7) GENERATED ALWAYS AS ROW END   DEFAULT (CONVERT([datetime2],'9999-12-31 23:59:59.9999999')) NOT NULL,
    CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED ([Id] ASC),
    PERIOD FOR SYSTEM_TIME ([VersionStartTime], [VersionEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[user].[UserProfileHistory], DATA_CONSISTENCY_CHECK=ON));

