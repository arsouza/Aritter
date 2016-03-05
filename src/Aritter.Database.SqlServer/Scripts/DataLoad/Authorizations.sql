MERGE INTO [Authorizations] AS Target
USING
(
	VALUES
	(1, 1, 1, 0, NEWID()),
	(2, 1, 1, 0, NEWID()),
	(3, 1, 1, 0, NEWID()),
	(4, 1, 1, 0, NEWID())
)
AS Source ([Id], [RoleId], [Allowed], [Denied], [Guid])
ON Target.[Id] = Source.[Id]
 
-- Update Rows
WHEN MATCHED THEN
UPDATE SET
	[Id] = source.[Id],
	[RoleId] = source.[RoleId],
	[Allowed] = source.[Allowed],
	[Denied] = source.[Denied],
	[Guid] = source.[Guid]
 
-- Insert Rows
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id], [RoleId], [Allowed], [Denied], [Guid])
VALUES ([Id], [RoleId], [Allowed], [Denied], [Guid])
 
-- Delete Rows
WHEN NOT MATCHED BY SOURCE THEN
DELETE;
