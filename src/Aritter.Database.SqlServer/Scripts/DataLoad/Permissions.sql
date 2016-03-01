SET IDENTITY_INSERT [dbo].[Permissions] ON
GO
 
MERGE INTO [Permissions] AS Target
USING
(
	VALUES
	(1, 1, 1, NEWID()),
	(2, 1, 2, NEWID()),
	(3, 1, 4, NEWID()),
	(4, 1, 8, NEWID())
)
AS Source ([Id], [FeatureId], [Rule], [Guid])
ON Target.[Id] = Source.[Id]
 
-- Update Rows
WHEN MATCHED THEN
UPDATE SET
	[FeatureId] = source.[FeatureId],
	[Rule] = source.[Rule],
	[Guid] = source.[Guid]
 
-- Insert Rows
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id], [FeatureId], [Rule], [Guid])
VALUES ([Id], [FeatureId], [Rule], [Guid])
 
-- Delete Rows
WHEN NOT MATCHED BY SOURCE THEN
DELETE;
 
SET IDENTITY_INSERT [dbo].[Permissions] OFF
GO
