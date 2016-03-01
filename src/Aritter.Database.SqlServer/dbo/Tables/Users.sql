CREATE TABLE [dbo].[Users] (
    [Id]                 INT              IDENTITY (1, 1) NOT NULL,
    [UserName]           VARCHAR (100)    NOT NULL,
    [FirstName]          VARCHAR (100)    NOT NULL,
    [LastName]           VARCHAR (100)    NULL,
    [Email]              VARCHAR (255)    NOT NULL,
    [MustChangePassword] BIT              NOT NULL,
    [IsActive]           BIT              NOT NULL,
    [Guid]               UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_UserUsername]
    ON [dbo].[Users]([UserName] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_UserMailAddress]
    ON [dbo].[Users]([Email] ASC);

