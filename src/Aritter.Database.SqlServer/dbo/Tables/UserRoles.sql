CREATE TABLE [dbo].[UserRoles] (
    [Id]     INT              IDENTITY (1, 1) NOT NULL,
    [UserId] INT              NOT NULL,
    [RoleId] INT              NOT NULL,
    [Guid]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_dbo.UserRoles] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.UserRoles_dbo.Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id]),
    CONSTRAINT [FK_dbo.UserRoles_dbo.Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_UserRole]
    ON [dbo].[UserRoles]([UserId] ASC, [RoleId] ASC);

