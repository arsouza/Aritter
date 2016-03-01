CREATE TABLE [dbo].[Features] (
    [Id]          INT              IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50)     NOT NULL,
    [Description] VARCHAR (100)    NULL,
    [Guid]        UNIQUEIDENTIFIER NOT NULL,
    [ModuleId]    INT              NOT NULL,
    CONSTRAINT [PK_dbo.Features] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Features_dbo.Modules_Module_Id] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Modules] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ModuleId]
    ON [dbo].[Features]([ModuleId] ASC);

