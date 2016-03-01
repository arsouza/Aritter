CREATE TABLE [dbo].[Roles] (
    [Id]          INT              IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50)     NOT NULL,
    [Description] VARCHAR (255)    NULL,
    [ModuleId]    INT              NOT NULL,
    [Guid]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Roles_dbo.Modules_IdModule] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Modules] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Role]
    ON [dbo].[Roles]([Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ModuleId]
    ON [dbo].[Roles]([ModuleId] ASC);

