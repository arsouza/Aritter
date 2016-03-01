SET IDENTITY_INSERT [dbo].[Features] ON
GO
 
MERGE INTO [Features] AS Target
USING
(
	VALUES (1, 'Feat1', 'Feature 1', NEWID(), 1)
)
AS Source ([Id], [Name], [Description], [Guid], [IdModule])
ON Target.[Id] = Source.[Id]
 
-- Update Rows
WHEN MATCHED THEN
UPDATE SET
	[Name] = source.[Name],
	[Description] = source.[Description],
	[Guid] = source.[Guid],
	[IdModule] = source.[IdModule]
 
-- Insert Rows
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id], [Name], [Description], [Guid], [IdModule])
VALUES ([Id], [Name], [Description], [Guid], [IdModule])
 
-- Delete Rows
WHEN NOT MATCHED BY SOURCE THEN
DELETE;
 
SET IDENTITY_INSERT [dbo].[Features] OFF
GO
