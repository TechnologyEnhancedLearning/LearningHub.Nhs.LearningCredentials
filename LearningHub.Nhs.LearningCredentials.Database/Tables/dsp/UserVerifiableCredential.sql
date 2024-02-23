CREATE TABLE [dsp].[UserVerifiableCredential] (
    [Id]                               INT                IDENTITY (1, 1) NOT NULL,
    [VerifiableCredentialId]           INT                NOT NULL,
    [UserVerifiableCredentialStatusId] INT                NOT NULL,
    [UserId]                           INT                NOT NULL,
    [ActivityDate]                     DATETIMEOFFSET     NOT NULL,
    [ExpiryDate]                       DATETIMEOFFSET     NOT NULL,
    [AttainmentStatus]                 NVARCHAR(50)       NOT NULL,
    [AddedToDSPDate]                   DATETIMEOFFSET (7) NULL,
    [DSPCode]                          NVARCHAR (256)     NULL,
    [SerialNumber]                     NVARCHAR (256)     NULL,
    [Deleted]                          BIT                NOT NULL,
    [CreateUserId]                     INT                NOT NULL,
    [CreateDate]                       DATETIMEOFFSET (7) NOT NULL,
    [AmendUserId]                      INT                NOT NULL,
    [AmendDate]                        DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_UserVerifiableCredential] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserVerifiableCredential_UserProfile] FOREIGN KEY ([UserId]) REFERENCES [user].[UserProfile] ([Id]),
    CONSTRAINT [FK_UserVerifiableCredential_UserVerifiableCredentialStatus] FOREIGN KEY ([UserVerifiableCredentialStatusId]) REFERENCES [dsp].[UserVerifiableCredentialStatus] ([Id]),
    CONSTRAINT [FK_UserVerifiableCredential_VerifiableCredential] FOREIGN KEY ([VerifiableCredentialId]) REFERENCES [dsp].[VerifiableCredential] ([Id])
);



