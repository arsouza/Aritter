CREATE TABLE [dbo].[Permissions] (
    [Id] [int] NOT NULL IDENTITY,
    [FeatureId] [int] NOT NULL,
    [Rule] [int] NOT NULL,
    [Guid] [uniqueidentifier] NOT NULL,
    CONSTRAINT [PK_dbo.Permissions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_dbo.Permissions_dbo.Features_FeatureId] FOREIGN KEY ([FeatureId]) REFERENCES [dbo].[Features] ([Id])
)

GO
CREATE UNIQUE INDEX [UQ_Permission]
    ON [dbo].[Permissions]([FeatureId], [Rule])