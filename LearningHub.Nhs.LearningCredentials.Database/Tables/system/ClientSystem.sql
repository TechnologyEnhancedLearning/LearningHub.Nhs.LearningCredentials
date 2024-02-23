CREATE TABLE [system].[ClientSystem] (
    [Id]           INT                NOT NULL,
    [Name]         NVARCHAR (50)      NOT NULL,
    [Origin]       NVARCHAR (128)     NULL,
    [Provider]     NVARCHAR (128)     NULL,
    [Deleted]      BIT                NOT NULL,
    [CreateUserId] INT                NOT NULL,
    [CreateDate]   DATETIMEOFFSET (7) NOT NULL,
    [AmendUserId]  INT                NOT NULL,
    [AmendDate]    DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_ClientSystem] PRIMARY KEY CLUSTERED ([Id] ASC)
);

