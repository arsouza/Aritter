CREATE TABLE [dbo].[UserPasswords] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [UserId]       INT              NOT NULL,
    [PasswordHash] VARCHAR (50)     NOT NULL,
    [Date]         DATETIME         NOT NULL,
    [Guid]         UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_dbo.UserPasswords] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.UserPasswords_dbo.Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[UserPasswords]([UserId] ASC);

