SET IDENTITY_INSERT [dbo].[Roles] ON
GO
 
MERGE INTO [Roles] AS Target
USING
(
	VALUES (1, 'Administrators', NULL, 1, NEWID())
)
AS Source ([Id], [Name], [Description], [IdModule], [Guid])
ON Target.[Id] = Source.[Id]
 
-- Update Rows
WHEN MATCHED THEN
UPDATE SET
	[Name] = source.[Name],
	[Description] = source.[Description],
	[IdModule] = source.[IdModule],
	[Guid] = source.[Guid]
 
-- Insert Rows
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id], [Name], [Description], [IdModule], [Guid])
VALUES ([Id], [Name], [Description], [IdModule], [Guid])
 
-- Delete Rows
WHEN NOT MATCHED BY SOURCE THEN
DELETE;
 
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
