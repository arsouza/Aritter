CREATE TABLE [dbo].[RoleMenus] (
    [Id]     INT              IDENTITY (1, 1) NOT NULL,
    [MenuId] INT              NOT NULL,
    [RoleId] INT              NOT NULL,
    [Guid]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_dbo.RoleMenus] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.RoleMenus_dbo.Menus_MenuId] FOREIGN KEY ([MenuId]) REFERENCES [dbo].[Menus] ([Id]),
    CONSTRAINT [FK_dbo.RoleMenus_dbo.Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_RoleMenu]
    ON [dbo].[RoleMenus]([MenuId] ASC, [RoleId] ASC);

