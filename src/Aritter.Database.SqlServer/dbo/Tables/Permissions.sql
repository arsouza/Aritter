CREATE TABLE [dbo].[Permissions] (
    [Id]        INT              IDENTITY (1, 1) NOT NULL,
    [FeatureId] INT              NOT NULL,
    [Rule]      INT              NOT NULL,
    [Guid]      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_dbo.Permissions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Permissions_dbo.Features_FeatureId] FOREIGN KEY ([FeatureId]) REFERENCES [dbo].[Features] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Permission]
    ON [dbo].[Permissions]([FeatureId] ASC, [Rule] ASC);

