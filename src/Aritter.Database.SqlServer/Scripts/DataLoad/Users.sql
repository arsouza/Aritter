SET IDENTITY_INSERT [dbo].[Users] ON
GO

MERGE INTO [Users] AS Target 
USING
(
	VALUES (1, 'admin', 'Administrator', null, 'admin@aritter.com', 0, newid(), 1)
) 
AS Source ([Id], [UserName], [FirstName], [LastName], [Email], [MustChangePassword], [Guid], [IsActive]) 
ON Target.[Id] = Source.[Id]

-- Atualiza registros existentes
WHEN MATCHED THEN 
UPDATE SET
	[UserName] = source.[UserName],
	[FirstName] = source.[FirstName],
	[LastName] = source.[LastName],
	[Email] = source.[Email],
	[MustChangePassword] = source.[MustChangePassword],
	[Guid] = source.[Guid],
	[IsActive] = source.[IsActive]

-- Insere registros não existentes 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id], [UserName], [FirstName], [LastName], [Email], [MustChangePassword], [Guid], [IsActive]) 
VALUES ([Id], [UserName], [FirstName], [LastName], [Email], [MustChangePassword], [Guid], [IsActive]) 

-- Remove registros que existem na tabela mas que não existe na origem
WHEN NOT MATCHED BY SOURCE THEN 
DELETE;

SET IDENTITY_INSERT [dbo].[Users] OFF
GO