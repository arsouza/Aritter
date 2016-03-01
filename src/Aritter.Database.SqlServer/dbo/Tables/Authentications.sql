CREATE TABLE [dbo].[Authentications] (
    [Id]       INT              IDENTITY (1, 1) NOT NULL,
    [UserId]   INT              NULL,
    [UserName] VARCHAR (20)     NULL,
    [Date]     DATETIME         NOT NULL,
    [State]    INT              NOT NULL,
    [Guid]     UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_dbo.Authentications] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Authentications_dbo.Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[Authentications]([UserId] ASC);

