CREATE TABLE [dbo].[Modules] (
    [Id]          INT              IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50)     NOT NULL,
    [Description] VARCHAR (255)    NULL,
    [Guid]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_dbo.Modules] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Module]
    ON [dbo].[Modules]([Name] ASC);

