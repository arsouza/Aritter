CREATE TABLE [dbo].[Authorizations] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [PermissionId] INT              NOT NULL,
    [UserId]       INT              NULL,
    [RoleId]       INT              NULL,
    [Allowed]      BIT              NOT NULL,
    [Denied]       BIT              NOT NULL,
    [Guid]         UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_dbo.Authorizations] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Authorizations_dbo.Permissions_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [dbo].[Permissions] ([Id]),
    CONSTRAINT [FK_dbo.Authorizations_dbo.Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id]),
    CONSTRAINT [FK_dbo.Authorizations_dbo.Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_UserAuthorization]
    ON [dbo].[Authorizations]([PermissionId] ASC, [UserId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_RoleAuthorization]
    ON [dbo].[Authorizations]([PermissionId] ASC, [RoleId] ASC);

