CREATE TABLE [dsp].[VerifiableCredential] (
    [Id]                       INT                IDENTITY (1, 1) NOT NULL,
    [CredentialName]           NVARCHAR (128)     NOT NULL,
    [ClientSystemId]           INT                NOT NULL,
    [ClientSystemCredentialId] INT                NOT NULL,
    [Level]                    SMALLINT                NOT NULL DEFAULT 1,
    [ScopeName]                VARCHAR(100)       NOT NULL,
    [ClaimPrefix]              VARCHAR(10)        NOT NULL,
    [PeriodUnitId]             SMALLINT           NOT NULL,
    [PeriodQty]                SMALLINT           NOT NULL,
    [Deleted]                  BIT                NOT NULL,
    [CreateUserId]             INT                NOT NULL,
    [CreateDate]               DATETIMEOFFSET (7) NOT NULL,
    [AmendUserId]              INT                NOT NULL,
    [AmendDate]                DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_VerifiableCredential] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_VerifiableCredential_ClientSystem] FOREIGN KEY ([ClientSystemId]) REFERENCES [system].[ClientSystem] ([Id])
);

