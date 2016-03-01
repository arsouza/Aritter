SET IDENTITY_INSERT [dbo].[Modules] ON
GO

MERGE INTO [Modules] AS Target 
USING
(
	VALUES (1, 'Security', NULL, NEWID())
) 
AS Source ([Id], [Name], [Description], [Guid]) 
ON Target.[Id] = Source.[Id]

-- Atualiza registros existentes
WHEN MATCHED THEN 
UPDATE SET
	[Name] = source.[Name],
	[Description] = source.[Description],
	[Guid] = source.[Guid]

-- Insere registros não existentes 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id], [Name], [Description], [Guid]) 
VALUES ([Id], [Name], [Description], [Guid]) 

-- Remove registros que existem na tabela mas que não existe na origem
WHEN NOT MATCHED BY SOURCE THEN 
DELETE;

SET IDENTITY_INSERT [dbo].[Modules] OFF
GO