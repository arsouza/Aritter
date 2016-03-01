SET IDENTITY_INSERT [dbo].[Authorizations] ON
GO
 
MERGE INTO [Authorizations] AS Target
USING
(
	VALUES
	(1, 1, NULL, 1, 1, 0, NEWID()),
	(2, 2, NULL, 1, 1, 0, NEWID()),
	(3, 3, NULL, 1, 1, 0, NEWID()),
	(4, 4, NULL, 1, 1, 0, NEWID())
)
AS Source ([Id], [PermissionId], [UserId], [RoleId], [Allowed], [Denied], [Guid])
ON Target.[Id] = Source.[Id]
 
-- Update Rows
WHEN MATCHED THEN
UPDATE SET
	[PermissionId] = source.[PermissionId],
	[UserId] = source.[UserId],
	[RoleId] = source.[RoleId],
	[Allowed] = source.[Allowed],
	[Denied] = source.[Denied],
	[Guid] = source.[Guid]
 
-- Insert Rows
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id], [PermissionId], [UserId], [RoleId], [Allowed], [Denied], [Guid])
VALUES ([Id], [PermissionId], [UserId], [RoleId], [Allowed], [Denied], [Guid])
 
-- Delete Rows
WHEN NOT MATCHED BY SOURCE THEN
DELETE;
 
SET IDENTITY_INSERT [dbo].[Authorizations] OFF
GO
