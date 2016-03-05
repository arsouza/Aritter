CREATE TABLE [dbo].[Authorizations] (
    [Id] [int] NOT NULL,
    [RoleId] [int] NOT NULL,
    [Allowed] [bit] NOT NULL,
    [Denied] [bit] NOT NULL,
    [Guid] [uniqueidentifier] NOT NULL,
    CONSTRAINT [PK_dbo.Authorizations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_dbo.Authorizations_dbo.Permissions_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Permissions] ([Id]),
    CONSTRAINT [FK_dbo.Authorizations_dbo.Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id])
)

GO
CREATE INDEX [IX_Id] ON [dbo].[Authorizations]([Id])

GO
CREATE UNIQUE INDEX [UQ_RoleAuthorization] ON [dbo].[Authorizations]([Id], [RoleId])

