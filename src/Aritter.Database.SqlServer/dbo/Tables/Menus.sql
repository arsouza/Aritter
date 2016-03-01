CREATE TABLE [dbo].[Menus] (
    [Id]          INT              IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50)     NOT NULL,
    [Description] VARCHAR (100)    NULL,
    [Image]       VARCHAR (200)    NULL,
    [Url]         VARCHAR (100)    NULL,
    [ParentId]    INT              NULL,
    [ModuleId]    INT              NOT NULL,
    [Guid]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_dbo.Menus] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Menus_dbo.Menus_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Menus] ([Id]),
    CONSTRAINT [FK_dbo.Menus_dbo.Modules_ModuleId] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Modules] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Feature]
    ON [dbo].[Menus]([ModuleId] ASC, [ParentId] ASC);

