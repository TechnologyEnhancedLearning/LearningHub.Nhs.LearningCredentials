CREATE TABLE dsp.PeriodUnit (
    [Id]            INT NOT NULL,
    [Name]          NVARCHAR (128)     NOT NULL,
    [Deleted]       BIT                NOT NULL,
    [CreateUserId]  INT                NOT NULL,
    [CreateDate]    DATETIMEOFFSET (7) NOT NULL,
    [AmendUserId]   INT                NOT NULL,
    [AmendDate]     DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_PeriodUnit] PRIMARY KEY CLUSTERED ([Id] ASC)
  );
