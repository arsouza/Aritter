SET IDENTITY_INSERT [dbo].[UserRoles] ON
GO

MERGE INTO [UserRoles] AS Target 
USING
(
	VALUES (1, 1, 1, NEWID())
) 
AS Source ([Id], [UserId], [RoleId], [Guid]) 
ON Target.[Id] = Source.[Id]

-- Atualiza registros existentes
WHEN MATCHED THEN 
UPDATE SET
	[UserId] = source.[UserId],
	[RoleId] = source.[RoleId],
	[Guid] = source.[Guid]

-- Insere registros não existentes 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id], [UserId], [RoleId], [Guid]) 
VALUES ([Id], [UserId], [RoleId], [Guid]) 

-- Remove registros que existem na tabela mas que não existe na origem
WHEN NOT MATCHED BY SOURCE THEN 
DELETE;

SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO